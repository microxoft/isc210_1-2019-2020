using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovementBehaviour : MonoBehaviour
{
    float accelerationX = -9.8f, currentSpeedX;
    const float startingPositionX = 10f;
    Vector3 _deltaPos;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeedX = 0;
        transform.position = new Vector3(startingPositionX, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos = new Vector3(currentSpeedX * Time.deltaTime + (accelerationX * Mathf.Pow(Time.deltaTime, 2) / 2), 0f);

        currentSpeedX += accelerationX * Time.deltaTime;

        transform.Translate(_deltaPos);
    }
}
