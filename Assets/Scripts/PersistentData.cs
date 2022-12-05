using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    public string playerName;
    public string bestPlayer;
    public int bestScore = 0;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
       Instance=this;
       DontDestroyOnLoad(gameObject); 
    }
    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.bestScore = PersistentData.Instance.bestScore;
        data.bestplayer = PersistentData.Instance.bestPlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PersistentData.Instance.bestPlayer = data.bestplayer;
            PersistentData.Instance.bestScore = data.bestScore;

        }
    }

    [System.Serializable]
    class SaveData
    {
        public string bestplayer;
        public int bestScore;
    }
}
