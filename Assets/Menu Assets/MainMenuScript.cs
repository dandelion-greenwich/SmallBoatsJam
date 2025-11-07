using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void BoatSelect()
    {
        SceneManager.LoadScene("Boat Select");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
