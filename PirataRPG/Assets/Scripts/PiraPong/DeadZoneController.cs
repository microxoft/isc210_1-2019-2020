using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    public TextMesh Player1Text, Player2Text;
    public GameObject Player1, Player2;
    static int _score1, _score2;
    public GameObject Ball;
    bool _player1Scored;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "bomb")
            return;

        _player1Scored = gameObject.name == "Player2DeadZone";
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if(_player1Scored)
        {
            _score1++;
            Player1Text.text = _score1.ToString();
            Ball.transform.SetParent(Player1.transform);
            Ball.transform.localPosition = new Vector3(1, 0);
        }
        else
        {
            _score2++;
            Player2Text.text = _score2.ToString();
            Ball.transform.SetParent(Player2.transform);
            Ball.transform.localPosition = new Vector3(-1, 0);
        }
    }
}
