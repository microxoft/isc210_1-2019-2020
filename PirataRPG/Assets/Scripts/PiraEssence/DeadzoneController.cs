using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneController : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
