using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARSpawnBt : MonoBehaviour
{
    public ARPlaceOnPlane aRPlace;

    public Toggle toggle;
    public Image image;
    public int index;

    GameObject target;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(ToggleActiveToy);
    }

    public void ToggleActiveToy(bool active)
    {
        if (active == true)
        {
            target = aRPlace.prefabs[index];
            target.SetActive(false);
            aRPlace.selectIndex = index;
            image.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            target = aRPlace.prefabs[index];
            target.SetActive(true);
            aRPlace.selectIndex = index;
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
