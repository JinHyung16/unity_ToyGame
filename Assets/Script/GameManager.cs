using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject toyshopPanel;
    public GameObject inventoryPanel;

    Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        upgradePanel.SetActive(false);
        toyshopPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }
    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ARView()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Back()
    {
        if (scene.name == "ARScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void UpgradePanel()
    {
        upgradePanel.SetActive(true);
    }
    public void ToyShopPanel()
    {
        toyshopPanel.SetActive(true);
    }
    public void InventoryPanel()
    {
        inventoryPanel.SetActive(true);
    }

}
