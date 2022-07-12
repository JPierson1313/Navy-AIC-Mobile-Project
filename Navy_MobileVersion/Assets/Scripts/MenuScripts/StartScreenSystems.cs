using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenSystems : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject scenariosCanvas;
    [SerializeField] GameObject creditsCanvas;

    [Header("Scenario String Names")]
    [SerializeField] string scenario1String;
    [SerializeField] string scenario2String;
    [SerializeField] string scenario3String;
    [SerializeField] string scenario4String;
    
    public void StartButton()
    {
        mainMenuCanvas.SetActive(false);
        scenariosCanvas.SetActive(true);
    }

    public void Scenario1Button()
    {
        scenariosCanvas.SetActive(false);
        SceneManager.LoadScene(scenario1String);
    }

    public void Scenario2Button()
    {
        scenariosCanvas.SetActive(false);
        SceneManager.LoadScene(scenario2String);
    }

    public void Scenario3Button()
    {
        scenariosCanvas.SetActive(false);
        SceneManager.LoadScene(scenario3String);
    }

    public void Scenario4Button()
    {
        scenariosCanvas.SetActive(false);
        SceneManager.LoadScene(scenario4String);
    }

    public void CreditsButton()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackToMenuButton()
    {
        creditsCanvas.SetActive(false);
        scenariosCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
