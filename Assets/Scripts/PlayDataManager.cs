using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class PlayDataManager : MonoBehaviour
{
    public static PlayDataManager Instance{get; private set;} = null;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        userName = defaultName;
    }


    public TMP_InputField userNameField;

    public string defaultName = "User";
    public string userName;

    public void SetUserName(string name){
        userName = name;
    }

    public void SetUserNameField(TMP_InputField field){
        userNameField = field;
        SetUserNameFieldListener();
    }

    public void SetUserNameFieldListener(){
        if(userNameField != null){
            userNameField.onEndEdit.AddListener(delegate {SetUserName(userNameField.text);});
            SetUserName(userNameField.text);
        } else {
            SetUserName(defaultName);
        }
    }



    // Control Savedata

    public MainManager mainManager;

    [System.Serializable]
    public class ScoreData{
        public string name;
        public int score;
    };

    public void SaveScoreData(){
        if(mainManager == null){
            Debug.Log("No MainManager");
            return;
        }

        ScoreData scoreData = new ScoreData();
        scoreData.name = userName;
        scoreData.score = mainManager.m_Points;

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(scoreData));
        Debug.Log("Data saved to " + Application.persistentDataPath);
    }

    public ScoreData LoadScoreData(){
        ScoreData scoreData = new ScoreData();

        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            scoreData = JsonUtility.FromJson<ScoreData>(File.ReadAllText(path));
        }

        return scoreData;
    }
}
