using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public GameObject Player;
    string path;
    bool clearSave = false;

    void Start()
    {
        path = Application.dataPath + "/game.save";
        LoadFile();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            ClearSave();
        }
    }

    private void OnApplicationQuit()
    {
        if (!clearSave)
        {
            SaveFile();
        }
    }

    public void ClearSave()
    {
        File.WriteAllText(path, "");
        clearSave = true;
    }

    public void SaveFile()
    {
        try
        {
            File.WriteAllText(path, Player.transform.position.ToString());
        }
        catch (System.Exception exep)
        {
            print("Error while saving to game.save file: " + exep.Message + " [in Save() function]");
        }
    }

    public void LoadFile()
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
            print("Error loading file: " + exep.Message);
        }
    }
}

//public class Save : MonoBehaviour
//{
    


    /// <param name="go">GameObject of the object you want to save its position</param>
    // public void Init(GameObject go)
    // {
    //     path = Application.dataPath + "/game.save";
    //     clearSave = false;
    //     Player = go;
    // }

    

    // public void Encript()
    // {
    //     print("Encripting save file");
    //     File.Encrypt(path);
    //     print("Encripting done");
    // }
    // 
    // public void Decript()
    // {
    //     print("Decripting save file");
    //     File.Decrypt(path);
    //     print("Decripting done, reading file...");
    // }
//}
