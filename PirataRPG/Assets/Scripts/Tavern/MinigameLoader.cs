using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameLoader : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {   
        if (!Input.GetButtonDown("Fire2"))
            return;

        switch(gameObject.name)
        {
            case "PongScene":
                SceneManager.LoadScene("PiraPong");
                break;
            case "PiraEssenceScene":
                SceneManager.LoadScene("PiraEssence");
                break;
            case "BrickBreakerScene":
                //SceneManager.LoadScene("PiraPong");
                break;
            case "MoronPongScene":
                //SceneManager.LoadScene("PiraPong");
                break;
        }
    }
}
