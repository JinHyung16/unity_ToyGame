using UnityEngine;

public class DollHouseManager : MonoBehaviour
{
    public GameObject[] rooms;

    [HideInInspector]
    public bool[] isOpen = { false, };

    [HideInInspector]
    public int index;

    //about action
    public GameObject[] actionRooms;

    Transform playerAction;
    Transform toysAction;

    private void Awake()
    {
        isOpen = new bool[rooms.Length];
        rooms[0].SetActive(true);
        isOpen[0] = true;
        for (int i = 1; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
            isOpen[i] = false;
        }
    }
    private void Start()
    {
        Data.M_Data.LoadDollHouse(this);
    }

    private void Update()
    {
        OpenRoom();
    }

    private void OpenRoom()
    {
        //추후 변경
        index = (Data.M_Data.Level - 1) / 10;
        if (index >= 10)
        {
            index = 10;
            return;
        }
        rooms[index].SetActive(true);
        Data.M_Data.SaveDollHouse(this);
        if (rooms[index].activeSelf)
        {
            return;
        }
    }

    //player search the action room transform
    public Transform PlayerActionTrans(string name)
    {
        switch (name)
        {
            case "sofa1":
                playerAction = actionRooms[0].transform;
                break;
            case "kitchen_chair1":
                playerAction = actionRooms[1].transform;
                break;
            case "kitchen_chair2":
                playerAction = actionRooms[2].transform;
                break;
            case "toilet":
                playerAction = actionRooms[3].transform;
                break;
            case "whiteChair":
                playerAction = actionRooms[4].transform;
                break;
            case "whiteChair1":
                playerAction = actionRooms[5].transform;
                break;
            case "lv6_chair":
                playerAction = actionRooms[6].transform;
                break;
            case "lv9_chair":
                playerAction = actionRooms[7].transform;
                break;
            case "bed1:Bed":
                playerAction = actionRooms[8].transform;
                break;
            case "singPos":
                playerAction = actionRooms[9].transform;
                break;
            default:
                playerAction = null;
                break;
        }

        return playerAction;
    }

    public Transform chairsTrans()
    {
        if(rooms[0].activeSelf)
        {
            toysAction = actionRooms[0].transform;
        }
        else if(rooms[1].activeSelf)
        {
            int a = Random.Range(1, 3);
            toysAction = actionRooms[a].transform;
        }
        else if(rooms[2].activeSelf)
        {
            toysAction = actionRooms[3].transform;
        }
        else if(rooms[4].activeSelf)
        {
            int b = Random.Range(4, 6);
            toysAction = actionRooms[b].transform;
        }
        else if (rooms[5].activeSelf)
        {
            toysAction = actionRooms[6].transform;
        }
        else if (rooms[8].activeSelf)
        {
            toysAction = actionRooms[7].transform;
        }

        return toysAction;
    }
}
