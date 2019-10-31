using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            Mathf.Clamp(Player.transform.position.y, -2.23f, 2.23f),
            gameObject.transform.position.z);
    }
}
