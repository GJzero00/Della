using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewPlayerData : MonoBehaviour
{




    public int nowScene;

    // public Vector3 Position => transform.position;

    // Start is called before the first frame update


    [System.Serializable]
    class SaveData
    {


        //public Vector3 PlayerPosition;
        public int scene;


    }


    public void Update()
    {

        nowScene = SceneManager.GetActiveScene().buildIndex;
        

    }




    public void Save()
    {

        SaveByPlayerPres();


    }



    public void Load()
    {
        LoadFromPlayerPrefs();
    }


    void SaveByPlayerPres()
    {
        var saveData = new SaveData();



        saveData.scene = nowScene;
        //saveData.PlayerPosition = Position;


        SaveSystem.SavePlayerPrefs("PlayerData", saveData);



    }

    void LoadFromPlayerPrefs()
    {
        var json = SaveSystem.LoadFromPlayerPrefs("PlayerData");
        var saveData = JsonUtility.FromJson<SaveData>(json);



        nowScene = saveData.scene;
        SceneManager.LoadScene(nowScene);
        //transform.position = saveData.PlayerPosition;


    }
}
