using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q1 : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
 

    List<string> textList = new List<string>();


    void Awake()
    {
        GetTectFormFile(textFile);
    }
    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            textLabel.text = textList[index];
            index++;
        }
    }

   void GetTectFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

       var lineDate = file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }
   
}

