using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    //about upgrade display
    public Text upgradeDispaly;

    public string upgradeName;

    //upgrade�� ���� �ڵ���� ���޷�
    [HideInInspector]
    public float goldTimeUpgrade;
    public float startGoldTimeUpgrade = 1;

    //upgrade�� ���� ��ġ��� ���޷�
    [HideInInspector]
    public float goldTuchUpgrade;
    public float startGoldTouchUpgrade = 1;

    //upgrade ���
    [HideInInspector]
    public float currentCost = 1;
    public float startCurrentCost = 1;

    [HideInInspector]
    public int level = 1;

    //upgrade �� �ڵ� ���޷��� �������� ��
    public float upgradePower_goldPerTime = 2;

    //upgrade �� ��ġ ���޷��� �������� ��
    public float upgradePower_goldPerTouch = 2;

    //upgrade �� cost ����
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

    //��� ��ȭ�� ���� �� upgarde ��� ����
    public void UpdateUpgrade()
    {
        goldTimeUpgrade = startGoldTimeUpgrade + upgradePower_goldPerTime * level;
        goldTuchUpgrade = startGoldTouchUpgrade + upgradePower_goldPerTouch * level;

        //upgrade ��� ����
        currentCost = startCurrentCost + costPower * Data.M_Data.Level;
    }

    public void UpdateUI()
    {
        upgradeDispaly.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + Data.M_Data.Level + "\nGoldPerTouch: " + goldTuchUpgrade;
    }
}
