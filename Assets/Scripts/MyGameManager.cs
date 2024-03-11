using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MyGameManager : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI textScore;

    
    public void AddScore(){
        Score++;
        textScore.text = Score.ToString() + " Points";
    }
}
