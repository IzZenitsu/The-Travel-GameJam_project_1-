using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour

{
    public GameObject MainMenu;
    public GameObject Credits;
    public GameObject HowToPlay;
    public GameObject Settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenu.SetActive(true);
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingsBtnClicked()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }
    public void HowToPlayBtnClicked()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
    }
    public void CreditsBtnClicked()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }
    public void BackBtnClicked()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        HowToPlay.SetActive(false);
        Settings.SetActive(false);
    }
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    public void PlayBtnClicked()
    {
        SceneManager.LoadScene(1);
    }
}
