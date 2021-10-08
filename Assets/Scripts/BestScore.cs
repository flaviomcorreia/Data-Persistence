using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class BestScore : MonoBehaviour
{
    public Text BestScoreText;

    private string playerName, playerOldRecord;

    private int topScore = 0;

    string path;

    void Awake(){
        path = Application.persistentDataPath + "/savefile.json";
        playerName = InputManager.Instance.nameInput;
        Restart();
        
    }


    public void setScore(int points){
        BestScoreText.text = "Best Score : " + playerName + $" : {points}";
        SaveUserInfo(points);
        
    }

    public void LoadNameAndScore(){
        Debug.Log(path);
        if(File.Exists(path)){
            Restart();
        }
        else{
            Debug.Log(Application.persistentDataPath + "/savefile.json");
            BestScoreText.text = "Best Score : Name: 0";   
        }
    }

    public void Restart(){
        
        if(File.Exists(path)){
            LoadUserInfo(path);
            BestScoreText.text = "Best Score : " + playerOldRecord + $" : {topScore}";
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
        Debug.Log("Saving sucessefully");
    }

    public void LoadUserInfo(string path){
       
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerOldRecord = data.userName;
            topScore = data.points;
            Debug.Log("Loading Sucessefully");
        
    }


}
