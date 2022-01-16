using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanelSlide : MonoBehaviour
{
    public Toggle toggle;

    public bool isSlide;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(SlideThePanel);
    }

    private void Update()
    {
        if(isSlide == true)
        {
            this.transform.Translate(new Vector3(245, 0, 0) * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(new Vector3(-245, 0, 0) * Time.deltaTime);
        }

        if(this.transform.position.x <= 55.0f)
        {
            this.transform.position = new Vector3(55, this.transform.position.y, this.transform.position.z);
        }
        else if(this.transform.position.x >= 300.0f)
        {
            this.transform.position = new Vector3(300, this.transform.position.y, this.transform.position.z);
        }
    }
    public void SlideThePanel(bool active)
    {
        if(active == true)
        {
            isSlide = true;
        }
        else
        {
            isSlide = false;
        }
    }
}
