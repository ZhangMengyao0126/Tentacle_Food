using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading
using UnityEngine.UI;  // Required for UI components

public class MenuOptions : MonoBehaviour
{
    void Start()
    {
        //Set Cursor to be visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    // This function is called when the "Play" button is clicked


    public void PlayGame()
    {
        // Replace "GameScene" with the actual name of your game scene
        SceneManager.LoadScene("Restaurant");
    }

    // This function is called when the "Options" button is clicked
    public void OpenOptions()
    {
        // For now, you could just log something or activate an Options menu
        Debug.Log("Options Menu Opened");
        // You can later expand this to show a settings/options menu
    }

    // This function is called when the "Quit" button is clicked
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
