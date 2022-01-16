using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TouchToStart : MonoBehaviour
{
    public GameObject panel;
    public Image image;
    public Text text;

    [SerializeField]
    [Range(0.01f, 10.0f)]
    private float fadeTime = 0;
    [SerializeField]
    private AnimationCurve fadeCurve = null;

    private IEnumerator fade;
    private IEnumerator blink;

    private void Awake()
    {
        panel.SetActive(true);
        fade = Fade(1, 0);
        blink = TextBlinking();
    }

    private void Start()
    {
        StartCoroutine(blink);
    }

    private IEnumerator TextBlinking()
    {
        while(true)
        {
            text.color = new Color(1, 1, 1, 0.0f);
            yield return Cashing.YieldInstruction.WaitForSeconds(0.4f);
            text.color = new Color(1, 1, 1, 0.6f);
            yield return Cashing.YieldInstruction.WaitForSeconds(0.4f);

            if (panel.activeSelf == false)
            {
                StopCoroutine(blink);
            }
        }
    }

    public void TouchStart()
    {
        StartCoroutine(fade);
    }

    private IEnumerator Fade(float start, float end)
    {
        float curTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            curTime += Time.deltaTime;
            percent = curTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            if(color.a <= 0.0f)
            {
                panel.SetActive(false);
                StopCoroutine(fade);

            }

            yield return null;
        }
    }    

}
