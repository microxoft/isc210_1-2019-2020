using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour
{
    float _currentPositionX, _scrollingSpeedX = 0.3f;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentPositionX += _scrollingSpeedX * Time.deltaTime;
        meshRenderer.material.mainTextureOffset = new Vector2(_currentPositionX, 0);
    }
}
