using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string bestPlayer;
    public int highestScore; // new variable declared

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadScore(); 
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int highestScore;
    }

    public bool CheckNewScore(int score){
        if(score > highestScore){
            highestScore = score;
            bestPlayer = playerName;
            SaveScore();
            return true;
        }
        else{return false;}
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highestScore = highestScore;
        data.bestPlayer = bestPlayer;
        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.highestScore;
            bestPlayer = data.bestPlayer;
        }
        else{
            highestScore = 0;
            bestPlayer = "Name";
        }
    }

    public string GetBestScore(){
        return "Best Score :"+ bestPlayer +" : "+highestScore;
    }

}
