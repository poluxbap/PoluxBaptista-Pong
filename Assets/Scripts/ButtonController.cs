using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject startMenu;
    public GameManager gameManager;
    public Player[] players;

    [Header("Warning Messages")]
    public GameObject[] playerWarning;

    private bool[] empty;

    private void Awake()
    {
        players = FindObjectsOfType<Player>();
        empty = new bool[players.Length];
    }

    public void CheckNames()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].playerName == "")
            {
                playerWarning[i].SetActive(true);
            }
            empty[i] = playerWarning[i].activeInHierarchy;
        }
        if (!IsEmpty())
        {
            startMenu.SetActive(false);
            gameManager.ResetBall();
            gameManager.ReactivateTriggers();
        }
    }    

    private bool IsEmpty()
    {
        for(int i = 0; i < empty.Length; i++)
        {
            if(empty[i])
            {
                return true;
            }
        }
        return false;
    }
}


