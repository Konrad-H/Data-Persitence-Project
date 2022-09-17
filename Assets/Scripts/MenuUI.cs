using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    // Start is called before the first frame update
    void Start()
    {
        
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
    void Update()
    {
        
    }
}
