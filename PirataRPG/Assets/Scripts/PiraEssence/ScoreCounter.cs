using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _blueSeaweedScore = 0, _lemonScore = 0, _orangeScore = 0, _grapeScore = 0, _cherryScore = 0, _bananaScore = 0, _lifeScore = 3;
    public TextMesh BlueSeaweedScoreText;
    public TextMesh LemonScoreText;
    public TextMesh OrangeScoreText;
    public TextMesh GrapeScoreText;
    public TextMesh CherryScoreText;
    public TextMesh BananaScoreText;
    public TextMesh LifeScoreText;

    public int GetLifeScore()
    {
        return _lifeScore;
    }

    public enum ScoreType
    {
        BlueSeaweed,
        Lemon,
        Orange,
        Grape,
        Cherry,
        Banana,
        Life,
        Enemy,
        All
    }

    void Start()
    {
        UpdateScoreText(ScoreType.All);
    }
    
    public void IncrementScore(ScoreType scoreType, int value = 1)
    {
        switch(scoreType)
        {
            case ScoreType.BlueSeaweed:
                _blueSeaweedScore += value;
                UpdateScoreText(ScoreType.BlueSeaweed);
                break;
            case ScoreType.Lemon:
                _lemonScore += value;
                UpdateScoreText(ScoreType.Lemon);
                break;
            case ScoreType.Orange:
                _orangeScore += value;
                UpdateScoreText(ScoreType.Orange);
                break;
            case ScoreType.Grape:
                _grapeScore += value;
                UpdateScoreText(ScoreType.Grape);
                break;
            case ScoreType.Cherry:
                _cherryScore += value;
                UpdateScoreText(ScoreType.Cherry);
                break;
            case ScoreType.Banana:
                _bananaScore += value;
                UpdateScoreText(ScoreType.Banana);
                break;
            case ScoreType.Life:
                _lifeScore += value;
                UpdateScoreText(ScoreType.Life);
                break;
        }
    }

    void UpdateScoreText(ScoreType scoreType)
    {
        if(scoreType == ScoreType.All || scoreType == ScoreType.Banana)
            BananaScoreText.text = _bananaScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.BlueSeaweed)
            BlueSeaweedScoreText.text = _blueSeaweedScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.Cherry)
            CherryScoreText.text = _cherryScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.Grape)
            GrapeScoreText.text = _grapeScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.Lemon)
            LemonScoreText.text = _lemonScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.Life)
            LifeScoreText.text = _lifeScore.ToString();
        if(scoreType == ScoreType.All || scoreType == ScoreType.Orange)
            OrangeScoreText.text = _orangeScore.ToString();
    }
}
