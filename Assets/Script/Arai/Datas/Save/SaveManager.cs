using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class SaveManager : MonoBehaviour
{
    private string path;
    public SaveData data;

    void Awake()
    {
//        path = Application.persistentDataPath + "/" + ".savedata.json";
        path = Application.dataPath + "/" + ".savedata.json";
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        var sw = new StreamWriter(path);
        sw.Write(json);
        sw.Flush();
        sw.Close();
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            var sr = new StreamReader(path);
            string save = sr.ReadToEnd();
            sr.Close();
            data = JsonUtility.FromJson<SaveData>(save);
        }
        else
        {
            data = new SaveData();
        }
    }
}
