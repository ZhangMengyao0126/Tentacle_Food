using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading
using UnityEngine.UI;  // Required for UI components

public class PauseOptions : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);

        // 初始化光标状态
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // 确保时间是正常流动的
        Time.timeScale = 1f;
    }
    // This function is called when the "Play" button is clicked

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

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

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
