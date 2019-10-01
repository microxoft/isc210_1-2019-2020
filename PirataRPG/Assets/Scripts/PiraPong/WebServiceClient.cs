using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class PongScores
{
    public int Id;
    public string PlayerName;
    public int Score;
}

public class WebServiceClient : MonoBehaviour
{
    UnityWebRequest www;
    public SoundManager soundManager;

    public static string WebServiceURL = "http://localhost:57085/api/values";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(SendWebRequest());
        }
    }

    IEnumerator SendWebRequest()
    {
        PongScores newScore = new PongScores { PlayerName = "Probando desde Unity", Score = 100 };
        www = UnityWebRequest.Put(WebServiceURL, JsonUtility.ToJson(newScore));
        www.SetRequestHeader("content-type", "application/json");
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);

        soundManager.SendMessage("PlayScoreSentSound");
    }
}
