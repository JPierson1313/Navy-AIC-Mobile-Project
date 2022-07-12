using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuSystems : MonoBehaviour
{
    [Header("Pause Menu Systems")]
    [SerializeField] string startScreenName;
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenuGroup;
    [SerializeField] Text hideUnhideText;
    private int pauseNum = 0;
    private int pauseMenuTextNum = 0;

    private void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        switch (pauseNum)
        {
            case 0:
                pauseButton.SetActive(true);
                break;
            case 1:
                Time.timeScale = 0.0f;
                pauseButton.SetActive(false);
                pauseMenuCanvas.SetActive(true);
                break;
            case 2:
                Time.timeScale = 1;
                pauseMenuCanvas.SetActive(false);
                pauseNum = 0;
                break;
        }

        switch (pauseMenuTextNum)
        {
            case 0:
                pauseMenuGroup.SetActive(true);
                hideUnhideText.text = "Hide\nPause";
                break;
            case 1:
                pauseMenuGroup.SetActive(false);
                hideUnhideText.text = "Unhide\nPause";
                break;
            case 2:
                pauseMenuTextNum = 0;
                break;
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseNum = 0;
        pauseMenuCanvas.SetActive(false);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        pauseNum = 0;
        SceneManager.LoadScene(startScreenName);
    }

    public void PauseButton()
    {
        pauseNum++;
    }

    public void HideUnhidePauseTextButton()
    {
        pauseMenuTextNum++;
    }
}
