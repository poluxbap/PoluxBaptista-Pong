using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ScorePoint();
        }
    }

    private void ScorePoint()
    {
        if(gameManager.canBallRun)
        {
            StateMachine.Instance.ResetPosition();
            player.AddPoint();
        }
    }
}
