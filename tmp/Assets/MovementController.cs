using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Player1")
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * 0.3f));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4));
        }
        else
        {
            float posX = gameObject.transform.position.x;
            transform.position = Vector3.Lerp(transform.position, GameObject.Find("Player1").transform.position, 0.01f);
            transform.position = new Vector3(posX, transform.position.y);
        }
        
    }
}
