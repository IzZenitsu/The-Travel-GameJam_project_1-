using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour

{
    public GameObject pausePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenuControl();
    }
    public void PauseMenuControl()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
                pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
        }
        
    }
    public void ResumeGame()
    { 
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    public void MainMenuBtnClicked()
    {
        SceneManager.LoadScene(0);
    }

}
