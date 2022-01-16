using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Character
{
    Animator animator;

    public DollHouseManager house;

    public Transform M_Trans;
    public Transform ResetTrans;

    public bool isReset = false;

    //touch to action target gameobject
    Transform actionTrans;

    private AToys atoys;
    private BToys btoys;

    //coroutine
    IEnumerator coroutineState;

    public enum State
    {
        Idle,
        Walk,
        Sit,
        Lie,
        Greeting,
        Sing,

    }

    public State m_state;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        m_state = State.Idle;
        coroutineState = StateChange();
        StartCoroutine(coroutineState);
    }

    IEnumerator StateChange()
    {
        while (true)
        {
            int i = Random.Range(0, 2);
            switch (i)
            {
                case 0:
                    m_state = State.Idle;
                    break;
                case 1:
                    m_state = State.Walk;
                    break;
                default:
                    break;
            }
            yield return Cashing.YieldInstruction.WaitForSeconds(7.0f);
        }
    }

    protected override void Update()
    {
        TouchToAction();

        switch (m_state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Walk:
                Walk();
                break;
            case State.Lie:
                Lie();
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

        if(isReset)
        {
            M_Trans.position = ResetTrans.position;
            isReset = false;
        }
    }
    private void TouchToAction()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Toy"))
                {
                    if (hit.collider.gameObject.activeSelf == false)
                    {
                        return;
                    }
                    else
                    {
                        StopCoroutine(coroutineState);
                        actionTrans = hit.collider.gameObject.transform;
                        m_state = State.Greeting;
                        atoys = hit.collider.gameObject.GetComponent<AToys>();
                        atoys.m_state = AToys.State.Greeting;
                    }
                }
                else if (hit.collider != null && hit.collider.CompareTag("Dino"))
                {
                    if (hit.collider.gameObject.activeSelf == false)
                    {
                        return;
                    }
                    else
                    {
                        StopCoroutine(coroutineState);
                        actionTrans = hit.collider.gameObject.transform;
                        m_state = State.Greeting;
                        btoys = hit.collider.gameObject.GetComponent<BToys>();
                        btoys.m_state = BToys.State.Greeting;
                    }
                }
                else if (hit.collider != null && hit.collider.CompareTag("SitPoint"))
                {
                    if (hit.collider.gameObject.activeSelf == false)
                    {
                        return;
                    }
                    else
                    {
                        StopCoroutine(coroutineState);
                        actionTrans = house.PlayerActionTrans(hit.collider.gameObject.name);
                        m_state = State.Sit;                        
                    }
                }
                else if (hit.collider != null && hit.collider.CompareTag("LiePoint"))
                {
                    if (hit.collider.gameObject.activeSelf == false)
                    {
                        return;
                    }
                    else
                    {
                        StopCoroutine(coroutineState);
                        actionTrans = house.PlayerActionTrans(hit.collider.gameObject.name);
                        m_state = State.Lie;
                    }
                }
                else if (hit.collider != null && hit.collider.CompareTag("SingPoint"))
                {
                    if (hit.collider.gameObject.activeSelf == false)
                    {
                        return;
                    }
                    else
                    {
                        StopCoroutine(coroutineState);
                        actionTrans = house.PlayerActionTrans(hit.collider.gameObject.name);
                        m_state = State.Sing;
                    }
                }
                else
                {
                    isReset = true;
                    StartCoroutine(coroutineState);
                }
            }
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
    protected override void Lie()
    {
        M_Trans.position = actionTrans.position;
        M_Trans.rotation = actionTrans.rotation;
        animator.SetInteger("Action", 2);
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
}
