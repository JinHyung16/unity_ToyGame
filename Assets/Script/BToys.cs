using System.Collections;
using UnityEngine;
public class BToys : Character
{
    Animator animator;

    public DollHouseManager house;

    public Transform M_Trans;
    public Transform ResetTrans;

    Transform actionTrans;

    public bool isGreeting = false;
    public bool isReset = false;

    public float stateTime = 7.0f;
    //about state
    public enum State
    {
        Idle,
        Walk,
        Sit,
        Greeting,
        Sing,
    }

    public State m_state;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    private void OnEnable()
    {
        m_state = State.Idle;
        StartCoroutine("StateChange");
    }

    IEnumerator StateChange()
    {
        while (true)
        {
            int i = Random.Range(0, 5);
            switch (i)
            {
                case 0:
                    isReset = true;
                    m_state = State.Idle;
                    stateTime = 5.0f;
                    break;
                case 1:
                    isReset = true;
                    m_state = State.Walk;
                    stateTime = 9.0f;
                    break;
                case 2:
                    actionTrans = house.chairsTrans();
                    break;
                case 3:
                    m_state = State.Greeting;
                    stateTime = 3.0f;
                    break;
                case 4:
                    if (house.actionRooms[9].activeSelf)
                    {
                        actionTrans = house.actionRooms[9].transform;
                        m_state = State.Sing;
                        stateTime = 8.0f;
                    }
                    else
                    {
                        m_state = State.Walk;
                    }
                    break;
            }
            yield return Cashing.YieldInstruction.WaitForSeconds(stateTime);
        }
    }

    protected override void Update()
    {
        switch (m_state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Walk:
                Walk();
                break;
            case State.Sit:
                Sit();
                break;
            case State.Greeting:
                Greeting();
                break;
            case State.Sing:
                Sing();
                break;
        }

        if (isGreeting)
        {
            m_state = State.Greeting;
            isGreeting = false;
        }

        if (isReset)
        {
            M_Trans.position = ResetTrans.position;
            isReset = false;
        }
    }
    protected override void Idle()
    {
        base.Idle();
        animator.SetInteger("Action", 9);

    }
    protected override void Walk()
    {
        base.Walk();
        animator.SetInteger("Action", 0);
    }

    protected override void Sit()
    {
        M_Trans.position = actionTrans.position;
        M_Trans.rotation = actionTrans.rotation;
        animator.SetInteger("Action", 1);
    }
    protected override void Greeting()
    {
        animator.SetInteger("Action", 3);
    }

    protected override void Sing()
    {
        M_Trans.position = actionTrans.position;
        M_Trans.rotation = actionTrans.rotation;
        animator.SetInteger("Action", 4);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Toy") || other.CompareTag("Player"))
        {
            if(m_state == State.Idle || m_state == State.Walk)
            {
                m_state = State.Greeting;
            }
        }
    }
}
