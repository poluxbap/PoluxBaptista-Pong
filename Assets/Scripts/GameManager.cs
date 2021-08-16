using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Ball ball;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public StateMachine stateMachine;

    public Player[] players;

    public bool canBallRun = true;

    [Header("Menu")]
    public GameObject menuUI;

    private void Awake()
    {
        Instance = this;
        players = FindObjectsOfType<Player>();
    }

    public void ResetBall()
    {
        ball.CanMove(false);
        ball.ResetPosition();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayer()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    public void SetBallFree()
    {
        ball.CanMove(true);
    }

    public void StartGame()
    {
        ball.CanMove(true);
    }

    public void ReactivateTriggers()
    {
        canBallRun = true;
    }

    public void EndGame()
    {
        canBallRun = false;
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void StopGame()
    {
        menuUI.SetActive(true);
        ball.CanMove(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetWinner()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
