using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveNowScene : MonoBehaviour
{

    private const string currentSceneKey = "CurrentScene";
    private GameObject playerHealth;
    private bool sceneSaved = false;



    private void OnEnable()
    {
        playerHealth = GameObject.FindWithTag("Player");
        

    }

    private void Update()
    {
        if (playerHealth ==null && SceneManager.GetActiveScene().name !="mainsceen2" )
        { 
            SaveCurrentScene();
    
        }
    }

    public void SaveCurrentScene()
    {
        PlayerPrefs.SetString(currentSceneKey, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    
    public void LoadSavedScene()
    {
        if (PlayerPrefs.HasKey(currentSceneKey))
        {
            string sceneName = PlayerPrefs.GetString(currentSceneKey);
            SceneManager.LoadScene(sceneName);
        }
    }

    // 清除保存的場景
    public void ClearSavedScene()
    {
        PlayerPrefs.DeleteKey(currentSceneKey);
        PlayerPrefs.Save();
    }

    
}
