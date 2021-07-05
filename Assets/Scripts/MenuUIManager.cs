using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    PlayDataManager playDataManager;
    TMP_InputField userNameField;

    private void Start() {
        playDataManager = PlayDataManager.Instance;
        userNameField = GameObject.Find("UserNameTextField").GetComponent<TMP_InputField>();

        if(playDataManager != null)
            playDataManager.userNameField = userNameField;

        playDataManager.SetUserNameField(userNameField);
    }

    public void StartGame(){
        SceneManager.LoadScene("main");
    }
}
