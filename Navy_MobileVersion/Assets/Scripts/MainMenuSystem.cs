using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuSystem : MonoBehaviour
{

    [Header("Level Names")]
    [SerializeField] string Scenario1String;
    [SerializeField] string Scenario2String;
    [SerializeField] string SettingsString;
    [SerializeField] string CreditsString;

    public GameObject ScenarioSelect;
    public GameObject MainMenu;

    private void Awake()
    {
        MainMenu.SetActive(true);
        ScenarioSelect.SetActive(false);
    }

    public void StartButton()
    {
        MainMenu.SetActive(false);
        ScenarioSelect.SetActive(true);
    }

    public void ScenarioOneButton()
    {
        SceneManager.LoadScene(Scenario1String);
    }

    public void ScenarioTwoButton()
    {
        SceneManager.LoadScene(Scenario2String);
    }

    public void SettingsButton()
    {
        Debug.Log("Settings Under Maintenance");
        //SceneManager.LoadScene(SettingsString);
    }

    public void CreditsButton()
    {
        Debug.Log("Credits Under Maintenance");
        //SceneManager.LoadScene(CreditsString);
    }
}
