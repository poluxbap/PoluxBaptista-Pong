using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float speed;
    public Image image;
    public string playerName = "";
    public TMP_Text winnerText;

    [Header("Key setup")]
    public KeyCode keyCodeUp = KeyCode.UpArrow;
    public KeyCode keyCodeDown = KeyCode.DownArrow;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextScore;
    public int maxPoints = 2;

    private void Awake()
    {
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyCodeUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        }
        else if(Input.GetKey(keyCodeDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckPoints();
    }

    private void UpdateUI()
    {
        uiTextScore.text = currentPoints.ToString();
    }

    private void CheckPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            Highscore.Instanse.SavePlayerWin(this);
            winnerText.text = playerName + " WON!";
        }
    }

    public void ChangeColor(Color c)
    {
        image.color = c;
    }

    public void SetName(string n)
    {
        playerName = n;
    }
}
