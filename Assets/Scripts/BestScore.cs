using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class BestScore : MonoBehaviour
{
    public Text BestScoreText;

    private string playerName;

    private int topScore = 0;


    void Awake(){
        playerName = InputManager.Instance.nameInput;
        Restart();
        
    }


    public void setScore(int points){
        BestScoreText.text = "Best Score : " + playerName + $" : {points}";
        if(topScore > points){
            SaveUserInfo(points);
        }
        
    }

    public void Restart(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            LoadUserInfo(path);
            Debug.Log("Am I being called?");
            BestScoreText.text = "Best Score : " + playerName + $" : {topScore}";
        }
    }

    [System.Serializable]
    class SaveData{
        public string userName;
        public int points; 
    }

     public void SaveUserInfo(int points){
        SaveData data = new SaveData();
        data.userName = playerName;
        data.points = points;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserInfo(string path){
       
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.userName;
            topScore = data.points;
        
    }


}
