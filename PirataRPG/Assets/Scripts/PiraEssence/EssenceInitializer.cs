using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceInitializer : MonoBehaviour
{
    public List<GameObject> Essences;
    public GameObject Trap;
    GameObject _newObject;
    float _trapRate = 0.1f;
    const float _startingSeconds = 1f, _repeatingSeconds = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObject", _startingSeconds, _repeatingSeconds);
    }

    void InstantiateObject()
    {
        if (Random.Range(0f, 1f) <= _trapRate)
            _newObject = Trap;
        else
            _newObject = Essences[Random.Range(0, 6)];

        Instantiate(_newObject, new Vector3(0, Random.Range(-4, 5)), Quaternion.identity);

        _trapRate *= 1.01f;
    }
}
