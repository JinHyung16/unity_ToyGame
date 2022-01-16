using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBGM : MonoBehaviour
{
    public AudioSource DanceBGM;
    public AudioSource SingBMG;

    [HideInInspector]
    public bool isPlay;

    [HideInInspector]
    public int playIndex;
    private void Awake()
    {
        DanceBGM.mute = true;
        SingBMG.mute = true;
    }
    private void Update()
    {
        SelectBGM();
    }

    private void SelectBGM()
    {
        switch (playIndex)
        {
            case 0:
                Play(0);
                break;
            case 1:
                Play(1);
                break;
            default:
                playIndex = 9;
                break;
        }
    }

    private void Play(int i)
    {
        switch (i)
        {
            case 0:
                if(isPlay)
                {
                    SingBMG.mute = false;
                }
                else
                {
                    SingBMG.mute = true;
                    playIndex = 9;
                }
                break;
            case 1:
                if(isPlay)
                {
                    DanceBGM.mute = false;
                }
                else
                {
                    DanceBGM.mute = true;
                    playIndex = 9;
                }
                break;
        }
    }
}
