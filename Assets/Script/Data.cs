using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data datacontroller;

    public static Data M_Data
    {
        get
        {
            if (datacontroller == null)
            {
                datacontroller = FindObjectOfType<Data>();
                if (datacontroller == null)
                {
                    GameObject emptyObject = new GameObject("Data");
                    datacontroller = emptyObject.AddComponent<Data>();
                }
            }
            DontDestroyOnLoad(datacontroller);
            return datacontroller;
        }
    }

    #region Property of Game Data
    // save the Current Gold
    public float gold
    {
        get
        {
            return PlayerPrefs.GetFloat("Gold");
        }
        set
        {
            PlayerPrefs.SetFloat("Gold", value);
        }
    }

    // save the supply gold per time
    public float goldPerTime
    {
        get
        {
            return PlayerPrefs.GetFloat("GoldPerTime", 1);
        }
        set
        {
            PlayerPrefs.SetFloat("GoldPerTime", value);
        }
    }

    // save the supply gold per touch screen
    public float goldPerTouch
    {
        get
        {
            return PlayerPrefs.GetFloat("GoldPerTouch", 1000000);

        }
        set
        {
            PlayerPrefs.SetFloat("GoldPerTouch", value);
        }
    }

    // save the doll house level
    public int Level
    {
        get
        {
            return PlayerPrefs.GetInt("Level", 1);
        }
        set
        {
            PlayerPrefs.SetInt("Level", value);
        }
    }
    #endregion

    private void Awake()
    {
        // if you want to clear all data, use it
        //PlayerPrefs.DeleteAll();
    }


    #region PlayerPrefs GetBool & SetBool
    // PlayerPrefs GetBool 정의
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // PlayerPrefs SetBool 정의
    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    #endregion

    #region Save Data Load Data

    // save the upgrade button data
    public void SaveUpgradeButton(UpgradeButton upgradeBt)
    {
        string key = upgradeBt.name;
        PlayerPrefs.SetInt(key + "_lelve", upgradeBt.level);
        PlayerPrefs.SetFloat(key + "_goldTimeByUpgrade", upgradeBt.goldTimeUpgrade);
        PlayerPrefs.SetFloat(key + "_goldTouchByUpgrade", upgradeBt.goldTuchUpgrade);
        PlayerPrefs.SetFloat(key + "_cost", upgradeBt.currentCost);
    }

    // lode the upgrade button data
    public void LoadUpgradeButton(UpgradeButton upgradeBt)
    {
        string key = upgradeBt.name;
        upgradeBt.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeBt.goldTimeUpgrade = PlayerPrefs.GetFloat(key + "_goldTimeByUpgrade", upgradeBt.startGoldTimeUpgrade);
        upgradeBt.goldTuchUpgrade = PlayerPrefs.GetFloat(key + "_goldTouchByUpgrade", upgradeBt.startGoldTouchUpgrade);
        upgradeBt.currentCost = PlayerPrefs.GetFloat(key + "_cost", upgradeBt.startCurrentCost);
    }

    // save the purchased toy data
    public void SaveToyButton(ToyPurchase toyPurBt)
    {
        string key = toyPurBt.name;
        SetBool(key + "_purchased", toyPurBt.isPurchased);
    }

    // load the purchased toy data
    public void LoadToyButton(ToyPurchase toyPurBt)
    {
        string key = toyPurBt.name;
        toyPurBt.isPurchased = GetBool(key + "_purchased");
    }

    // save the opened room data as my level
    public void SaveDollHouse(DollHouseManager house)
    {
        string key = house.name;
        PlayerPrefs.SetInt(key + "_index", house.index);
        SetBool(key + "_open", house.isOpen[house.index]);
    }

    // load the opened room data
    public void LoadDollHouse(DollHouseManager house)
    {
        string key = house.name;
        house.index = PlayerPrefs.GetInt(key + "_index");
        house.isOpen[house.index] = GetBool(key + "_open");
    }

    #endregion
}

