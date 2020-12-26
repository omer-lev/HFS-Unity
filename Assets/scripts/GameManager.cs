using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    string path;
    public GameObject Player;

    void Start()
    {
        path = Application.dataPath + "/game.save";
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        File.WriteAllText(path, Player.transform.position.ToString());
    }

    private void Load()
    {
        string saveString = File.ReadAllText(path);
        string[] posString = saveString.Split(',', '(', ')');

        float posX = float.Parse(posString[1]);
        float posY = float.Parse(posString[2]);

        Player.transform.position = new Vector3(posX, posY, 0);
    }
}
