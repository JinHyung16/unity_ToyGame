using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCharacter : MonoBehaviour
{
    public ARBGM bgm;
    private Animator animator;

    public enum State
    {
        Greeting,
        Sing,
        Dance,
    }

    public State m_state;


    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        CheckBGM();
    }

    private void CheckBGM()
    {
        switch(bgm.playIndex)
        {
            case 0:
                Sing();
                break;
            case 1:
                Dance();
                break;
            default:
                Greeting();
                break;
        }
    }

    private void Greeting()
    {
        animator.SetInteger("isAction", 0);
    }
    private void Sing()
    {
        animator.SetInteger("isAction", 1);
    }
    private void Dance()
    {
        animator.SetInteger("isAction", 2);
    }
}
