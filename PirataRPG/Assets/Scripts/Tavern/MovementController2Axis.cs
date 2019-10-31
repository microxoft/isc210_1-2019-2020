using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2Axis : MonoBehaviour
{
    Vector3 _movementSpeed = new Vector3(10, 10), _deltaPos;
    Vector3 _runningSpeed = new Vector3(15, 15);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire3"))
            _deltaPos = new Vector3(_runningSpeed.x * Input.GetAxis("Horizontal"), _runningSpeed.y * Input.GetAxis("Vertical"));
        else
            _deltaPos = new Vector3(_movementSpeed.x * Input.GetAxis("Horizontal"), _movementSpeed.y * Input.GetAxis("Vertical"));

        //_deltaPos *= Time.deltaTime;

        //gameObject.transform.Translate(_deltaPos);
        gameObject.GetComponent<Rigidbody>().velocity = _deltaPos;
    }
}
