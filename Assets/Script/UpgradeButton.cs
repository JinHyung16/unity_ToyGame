using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    //about upgrade display
    public Text upgradeDispaly;

    public string upgradeName;

    //upgrade에 따른 자동골드 수급량
    [HideInInspector]
    public float goldTimeUpgrade;
    public float startGoldTimeUpgrade = 1;

    //upgrade에 따른 터치골드 수급량
    [HideInInspector]
    public float goldTuchUpgrade;
    public float startGoldTouchUpgrade = 1;

    //upgrade 비용
    [HideInInspector]
    public float currentCost = 1;
    public float startCurrentCost = 1;

    [HideInInspector]
    public int level = 1;

    //upgrade 시 자동 수급량에 곱해지는 양
    public float upgradePower_goldPerTime = 2;

    //upgrade 시 터치 수급량에 곱해지는 양
    public float upgradePower_goldPerTouch = 2;

    //upgrade 시 cost 증가
    public float costPower = 2;

    private void Start()
    {
        Data.M_Data.LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (Data.M_Data.gold >= currentCost)
        {
            Data.M_Data.gold -= currentCost;
            Data.M_Data.goldPerTouch += goldTuchUpgrade;
            Data.M_Data.goldPerTime += goldTimeUpgrade;
            Data.M_Data.Level += level;
            UpdateUpgrade();
            UpdateUI();
            Data.M_Data.SaveUpgradeButton(this);
        }
    }

    //얻는 재화량 증가 및 upgarde 비용 증가
    public void UpdateUpgrade()
    {
        goldTimeUpgrade = startGoldTimeUpgrade + upgradePower_goldPerTime * level;
        goldTuchUpgrade = startGoldTouchUpgrade + upgradePower_goldPerTouch * level;

        //upgrade 비용 증가
        currentCost = startCurrentCost + costPower * Data.M_Data.Level;
    }

    public void UpdateUI()
    {
        upgradeDispaly.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + Data.M_Data.Level + "\nGoldPerTouch: " + goldTuchUpgrade;
    }
}
