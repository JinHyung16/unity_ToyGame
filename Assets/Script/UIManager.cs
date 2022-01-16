using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Transform canvas;

    //about display
    public Text goldDisplay;
    public Text goldPerTouchDisplay;
    public Text levelDisplay;

    //about panel each buttons that shop and toyshop
    public GameObject ShopPanel;
    public GameObject ToyShopPanel;

    private void Awake()
    {
        ShopPanel.SetActive(false);
        ToyShopPanel.SetActive(false);
    }
    private void Update()
    {
        DisplayAboutData();
    }

    private void DisplayAboutData()
    {
        levelDisplay.text = Data.M_Data.Level.ToString();
        goldDisplay.text = Data.M_Data.gold.ToString();
        goldPerTouchDisplay.text = Data.M_Data.goldPerTouch.ToString();
    }

    public void ShopButton()
    {
        ShopPanel.transform.position = canvas.transform.position;
        ToyShopPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void ToyShopButton()
    {
        ToyShopPanel.transform.position = canvas.transform.position;
        ShopPanel.SetActive(false);
        ToyShopPanel.SetActive(true);
    }

    public void BackButton()
    {
        ToyShopPanel.SetActive(false);
        ShopPanel.SetActive(false);

    }
}
