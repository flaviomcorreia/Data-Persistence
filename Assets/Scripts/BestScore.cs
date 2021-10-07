using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text BestScoreText;

    private string playerName; 

    void Awake(){
        playerName = InputManager.Instance.nameInput;
        //BestScoreText.text = "Best Score : Name : 0";
    }


    public void setScore(int points){
        Debug.Log(playerName);
        BestScoreText.text = "Best Score :" + playerName + $": {points}";
    }
}
