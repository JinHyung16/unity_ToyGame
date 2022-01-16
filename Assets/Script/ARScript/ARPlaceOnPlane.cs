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

    //오브젝트 제어하기
    private void PlaceObjectByTouch()
    {
        //터치가 일어난 방향으로 ray 발사
        //그 위치에 오브젝트 생성시키고 여러개 생성 막기
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
            //카메라 센터에서 ray 발사
            Vector3 screenCenter = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            List<ARRaycastHit> hit = new List<ARRaycastHit>();
            arRayCast.Raycast(screenCenter, hit, TrackableType.All);

            //ray에 부딪힌게 있으면 0번째를 받아서 생성
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
