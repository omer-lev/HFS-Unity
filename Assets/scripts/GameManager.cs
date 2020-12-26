using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    string path;
    public GameObject Player;
    bool clearSave = false;

    void Start()
    {
        path = Application.dataPath + "/game.save";

        Load();
    }

    private void ClearSave()
    {
        File.WriteAllText(path, "");
        clearSave = true;
    }

    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            ClearSave();
        }
    }

    private void OnApplicationQuit()
    {
        if (!clearSave)
        {
            Save();
        }
    }

    private void Save()
    {
        File.WriteAllText(path, Player.transform.position.ToString());
    }

    private void Load()
    {
        try
        {
            string saveString = File.ReadAllText(path);
            string[] posString = saveString.Split(',', '(', ')');

            float posX, posY;

            posX = float.Parse(posString[1]);
            posY = float.Parse(posString[2]);

            Player.transform.position = new Vector3(posX, posY, 0);
        }
        catch (System.Exception exep)
        {
            print("No data in game.save: " + exep.Message);
        }
    }
}