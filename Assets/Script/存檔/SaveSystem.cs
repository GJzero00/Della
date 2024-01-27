using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data, true);

        Debug.Log(json);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();

    }

    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);





    }
}