using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
    using UnityEditor;
#endif
public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_Text bestScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = GameManager.Instance.GetBestScore();
    }
    public void StartNew()
    {
        if (username.text==""){
            Debug.Log("ENTER NAME PLS!");
        }
        else{
            GameManager.Instance.playerName = username.text;
            SceneManager.LoadScene(1);
        }
        
    }
    // Update is called once per frame
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
