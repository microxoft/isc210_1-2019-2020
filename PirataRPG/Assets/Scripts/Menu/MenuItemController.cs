using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions
{
    private static GameOptions _instance;
    public static GameOptions Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameOptions();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public string Name;
    public float Volume;
    public int Difficulty;
}

public class MenuItemController : MonoBehaviour
{
    static GameObject _optionsDialog;
    GameOptionsLoader _optionsLoader;
   
    private void Awake()
    {
        _optionsLoader = GameObject.Find("GlobalScriptsText").GetComponent<GameOptionsLoader>();

        if (_optionsDialog != null)
            return;

        _optionsDialog = GameObject.Find("OptionsDialog");
        _optionsDialog.SetActive(false);
    }

    public void OnMouseEnter()
    {
        if(!_optionsDialog.activeSelf)
            gameObject.transform.localScale *= 1.1f;
    }

    public void OnMouseExit()
    {
        if (!_optionsDialog.activeSelf)
            gameObject.transform.localScale /= 1.1f;
    }

    private void OnMouseDown()
    {
        if (_optionsDialog.activeSelf)
            return;

        switch (gameObject.name)
        {
            case "StartMenuItem":
                SceneManager.LoadScene("Tavern");
                break;
            case "OptionsMenuItem":
                // Show game options.
                OnMouseExit();
                _optionsDialog.SetActive(true);
                UpdateCanvasGUI();
                break;
            case "ExitMenuItem":
                Application.Quit();
                break;
        }
    }

    public void CancelDialog()
    {
        _optionsDialog.SetActive(false);
    }

    public void OkDialog()
    {

        //_name = GameObject.Find("NameText").GetComponent<UnityEngine.UI.InputField>().text;
        //_volume = GameObject.Find("VolumeSlider").GetComponent<UnityEngine.UI.Slider>().value;
        //_difficulty = GameObject.Find("DifficultyDropdown").GetComponent<UnityEngine.UI.Dropdown>().value;

        // Probando el PlayerPrefs.
        PlayerPrefs.SetString("PlayerName", GameOptions.Instance.Name);
        PlayerPrefs.Save();

        _optionsLoader.SaveGameOptions();

        CancelDialog();
    }

    public void NameChanged(UnityEngine.UI.InputField inputField)
    {
        GameOptions.Instance.Name = inputField.text;
    }

    public void VolumeChanged(UnityEngine.UI.Slider slider)
    {
        GameOptions.Instance.Volume = slider.value;
    }

    public void DifficultyChanged(UnityEngine.UI.Dropdown dropdown)
    {
        GameOptions.Instance.Difficulty = dropdown.value;
    }

    private void UpdateCanvasGUI()
    {
        GameObject.Find("NameText").GetComponent<UnityEngine.UI.InputField>().text = GameOptions.Instance.Name;
        GameObject.Find("VolumeSlider").GetComponent<UnityEngine.UI.Slider>().value = GameOptions.Instance.Volume;
        GameObject.Find("DifficultyDropdown").GetComponent<UnityEngine.UI.Dropdown>().value = GameOptions.Instance.Difficulty;
    }
}
