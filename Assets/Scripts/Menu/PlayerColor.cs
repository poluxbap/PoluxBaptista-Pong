using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
    public Color color;
    public Image image;
    public Player player;

    private void Awake()
    {
        image.color = color;
    }

    public void OnClick()
    {
        player.ChangeColor(color);
    }
}
