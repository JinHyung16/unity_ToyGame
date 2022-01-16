using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCotrol : MonoBehaviour
{
    Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void ARView()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Back()
    {
        if (scene.name == "ARScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
