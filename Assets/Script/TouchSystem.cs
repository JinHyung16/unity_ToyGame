using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSystem : MonoBehaviour
{
    public Transform world;
    public Transform cam;

    [SerializeField]
    private float rotateSpeed = 0.4f;
    [SerializeField]
    private float zoomSpeed = 1.0f;

    private float xAngle;
    private float yAngle;
    private float xAngleTemp;
    private float yAngleTemp;

    //touch move pos
    Vector2 startPos;
    Vector2 movingPos;

    //time
    [SerializeField]
    private float curTime;
    private float startTime;

    private void Start()
    {
        xAngle = world.rotation.eulerAngles.x;
        yAngle = world.rotation.eulerAngles.y;

        startTime = Time.time;

        StartCoroutine(GoldPerTimeSupply());
    }
    private void Update()
    {
        curTime += (Time.deltaTime - startTime);
        if (curTime >= 2.0f)
        {
            curTime = 0.0f;
        }
        GoldPerTouchSupply();
        RotatingWorld();
        ZoomCamera();
    }

    //�ð��� �ڵ����� �����ϴ� ���

    private IEnumerator GoldPerTimeSupply()
    {
        while (true)
        {
            float goldPerTime = Data.M_Data.goldPerTime;
            Data.M_Data.gold += goldPerTime;
            yield return Cashing.YieldInstruction.WaitForSeconds(3.0f);
        }
    }

    //ȭ�� ��ġ�� �����ϴ� ���
    private void GoldPerTouchSupply()
    {
        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    float goldPerTouch = Data.M_Data.goldPerTouch;
                    Data.M_Data.gold += goldPerTouch;
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void RotatingWorld()
    {
        if (Input.touchCount == 1)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPos = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    movingPos = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (movingPos.x - startPos.x) * 180 * 3.0f / Screen.width * rotateSpeed;
                    yAngle = yAngleTemp - (movingPos.y - startPos.y) * 90 * 3.0f / Screen.height * rotateSpeed;
                    if (yAngle >= 0)
                    {
                        yAngle = 0;
                    }
                    else if (yAngle < -0.2f)
                    {
                        yAngle = -0.2f;
                    }

                    world.rotation = Quaternion.Euler(yAngle, xAngle, 0);
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void ZoomCamera()
    {
        if (Input.touchCount == 2)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                // ��ġ�� �̵������� ���� �������� ��ġ ��ġ ���ϱ�
                Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                Vector2 secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                // ���� �����ӿ����� ��ġ ��ġ ��
                float prevPosDistance = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                // ���� �����ӿ����� ��ġ ��ġ ��
                float currentPosDistance = (firstTouch.position - secondTouch.position).magnitude;
                // ���� �����ӿ��� ���� �����ӱ����� ��ȭ�� �� �󸶳� ��� ���� �ܾƿ��ߴ��� ��ȭ��
                float zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomSpeed;

                // ���� �����ӿ����� �� ��ġ ������ ���� ���� �����ӿ����� �� ��ġ ���̰Ÿ� �񱳷� ���� �ܾƿ�
                if (prevPosDistance > currentPosDistance && cam.position.z > -20.0f) //�ܾƿ�
                {
                    cam.position += Vector3.back * zoomModifier * Time.deltaTime;
                }
                else if (prevPosDistance < currentPosDistance && cam.position.z < 40.0f) //����
                {
                    cam.position += Vector3.forward * zoomModifier * Time.deltaTime;
                }
            }
        }
    }


}
