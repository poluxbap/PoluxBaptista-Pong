using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [Header("References")]
    public TMP_Text nameText;
    public TMP_InputField nameInput;
    public GameObject inputFields;
    public Player player;
    
    public void ChangeName()
    {
        var text = nameInput.text;
        nameText.text = text;
        inputFields.SetActive(false);
        player.SetName(text);
    }
}
