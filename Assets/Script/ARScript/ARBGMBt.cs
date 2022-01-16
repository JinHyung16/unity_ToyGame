using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARBGMBt : MonoBehaviour
{
    public Toggle toggle;
    public Image image;
    public ARBGM arbgm;
    public int index;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(PlayBGM);
    }

    public void PlayBGM(bool active)
    {
        arbgm.playIndex = index;

        if (active == true)
        {
            arbgm.isPlay = true;
            image.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            arbgm.isPlay = false;
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
