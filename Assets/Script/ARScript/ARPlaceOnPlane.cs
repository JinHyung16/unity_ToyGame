using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRayCast;

    //public Camera arCam;
    //Pose placementPose;

    public GameObject[] prefabs;

    [HideInInspector]
    public int selectIndex;

    private void Awake()
    {
        Pooling();
    }
    private void Update()
    {
        //GetCenter();
        PlaceObjectByTouch();
    }

    private void Pooling()
    {
        for (int i = 0; i < 10; i++)
        {
            prefabs[i].SetActive(false);
        }
    }

    //������Ʈ �����ϱ�
    private void PlaceObjectByTouch()
    {
        //��ġ�� �Ͼ �������� ray �߻�
        //�� ��ġ�� ������Ʈ ������Ű�� ������ ���� ����
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                List<ARRaycastHit> hit = new List<ARRaycastHit>();
                if (arRayCast.Raycast(touch.position, hit, TrackableType.All))
                {
                    Pose hitPos = hit[0].pose;
                    if (!prefabs[selectIndex].activeSelf)
                    {
                        prefabs[selectIndex].SetActive(true);
                    }
                    else if (prefabs[selectIndex].activeSelf)
                    {
                        prefabs[selectIndex].transform.position = hitPos.position;
                        prefabs[selectIndex].transform.rotation = Quaternion.Euler(hitPos.rotation.x, hitPos.rotation.y + 180, hitPos.rotation.z);
                    }
                }
            }
        }
    }

    /*    private void GetCenter()
        {
            //ī�޶� ���Ϳ��� ray �߻�
            Vector3 screenCenter = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            List<ARRaycastHit> hit = new List<ARRaycastHit>();
            arRayCast.Raycast(screenCenter, hit, TrackableType.All);

            //ray�� �ε����� ������ 0��°�� �޾Ƽ� ����
            if (hit.Count > 0)
            {
                placementPose = hit[0].pose;
            }
            else
            {
                return;
            }
        }*/
}
