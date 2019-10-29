using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Ball;
    bool _cpuPlayer = true;
    bool _isPlayerOne;
    float _movementSpeed = 0.3f;
    const float _LOWERLIMIT = -3.4f, _UPPERLIMIT = 3.4f;
    Vector3 _deltaPos;
    Animator _animator;
    ScoreCounter _scoreCounter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _scoreCounter = GameObject.Find("GlobalScripts").GetComponent<ScoreCounter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _isPlayerOne = name == "Player1";

        //_isPlayerOne = gameObject.name == "Player1" ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cpuPlayer || _isPlayerOne)
        {
            _deltaPos = new Vector3(0, _movementSpeed * Input.GetAxis(_isPlayerOne ? "Player1" : "Player2"));

            if (_animator != null)
                _animator.SetFloat("SpeedY", _deltaPos.y);

            transform.Translate(_deltaPos);
        }
        else if(!_isPlayerOne && Ball != null)
        {
            _deltaPos = Vector3.Lerp(Ball.transform.position, gameObject.transform.position, 0.90f);
            _deltaPos.x = transform.position.x;
            transform.position = _deltaPos;
        }

        transform.position = new Vector3(gameObject.transform.position.x,
            Mathf.Clamp(gameObject.transform.position.y, _LOWERLIMIT, _UPPERLIMIT), 
            gameObject.transform.position.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        ScoreCounter.ScoreType scoreType;
        try
        {
            scoreType = (ScoreCounter.ScoreType)Enum.Parse(typeof(ScoreCounter.ScoreType), other.gameObject.tag);
        }
        catch (Exception)
        {
            return;
        }

        if (scoreType == ScoreCounter.ScoreType.Enemy)
            _scoreCounter.IncrementScore(ScoreCounter.ScoreType.Life, -1);
        else
            _scoreCounter.IncrementScore(scoreType);

        Destroy(other.gameObject);

        if (_scoreCounter.GetLifeScore() <= 0)
            Debug.Log("Game Over!");
    }
}
