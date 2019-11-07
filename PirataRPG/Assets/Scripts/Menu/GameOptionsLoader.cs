using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class GameOptionsLoader : MonoBehaviour
{
    string _localPath = "gameOptions.xml";

    private void Start()
    {
        LoadGameOptions();

        Debug.Log("En el playerprefs el nombre guardado es: " + PlayerPrefs.GetString("PlayerName", "Jhon Doe"));
    }

    public void SaveGameOptions()
    {
        using (Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + _localPath, FileMode.Create))
        {
            DataContractSerializer dcontract = new DataContractSerializer(typeof(GameOptions));
            dcontract.WriteObject(fileStream, GameOptions.Instance);
        }
    }

    public void LoadGameOptions()
    {
        using (Stream fileStream = new FileStream(Application.persistentDataPath + "\\" + _localPath, FileMode.Open))
        {
            DataContractSerializer dcontract = new DataContractSerializer(typeof(GameOptions));
            GameOptions.Instance = (GameOptions)dcontract.ReadObject(fileStream);
        }
    }
}
