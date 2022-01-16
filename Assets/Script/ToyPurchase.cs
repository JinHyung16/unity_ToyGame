using UnityEngine;
using UnityEngine.UI;

public class ToyPurchase : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject character;
    public Image toyImage;

    public float toyCost;

    [HideInInspector]
    public bool isPurchased = false;

    public Button m_Button;

    private void Start()
    {
        m_Button = GetComponent<Button>();
        toyImage = GetComponent<Image>();
        m_Button.interactable = true;
        toyImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        Data.M_Data.LoadToyButton(this);
    }

    private void Update()
    {
        if (Data.M_Data.gold >= toyCost)
        {
            toyImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        if (isPurchased)
        {
            m_Button.interactable = false;
        }
    }

    public void PurchaseToy()
    {
        if (Data.M_Data.gold >= toyCost)
        {
            Data.M_Data.gold -= toyCost;
            isPurchased = true;
            Data.M_Data.SaveToyButton(this);
            GetToy();
        }
    }

    private void GetToy()
    {
        character.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z + 3.0f);
        character.SetActive(true);
    }

}
