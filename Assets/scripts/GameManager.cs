using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    Save save;
    public GameObject player;

    void Start()
    {
        save.LoadFile();
        save.Init(player);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            save.ClearSave();
        }
    }

    private void OnApplicationQuit()
    {
        if (!save.clearSave)
        {
            save.SaveFile();
        }
    }
}

public class Save : MonoBehaviour
{
    GameObject Player;
    public string path;
    public bool clearSave;

    /// <summary>
    /// Used to initialize the components used inside this class
    /// </summary>
    /// <param name="go">GameObject of the object you want to save its position</param>
    public void Init(GameObject go)
    {
        path = Application.dataPath + "/game.save";
        clearSave = false;
        Player = go;
    }

    /// <summary>
    /// Deletes any data supplied to path
    /// </summary>
    public void ClearSave()
    {
        File.WriteAllText(path, "");
        clearSave = true;
    }

    /// <summary>
    /// Self explanetory...
    /// </summary>
    public void SaveFile()
    {
        try
        {
            print("Saving data to file");
            File.WriteAllText(path, Player.transform.position.ToString());
            print("Saving done");
        }
        catch (System.Exception exep)
        {
            print("Error loading file: " + exep.Message + " [in Save() function]");
        }
    }

    /// <summary>
    /// Self explanetory...
    /// </summary>
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
            print("Reading done");
        }
        catch (System.Exception exep)
        {
            print("Error loading file: " + exep.Message);
        }
    }

    /// <summary>
    /// Self explanetory...
    /// </summary>
    public void Encript()
    {
        print("Encripting save file");
        File.Encrypt(path);
        print("Encripting done");
    }

    /// <summary>
    /// Self explanetory...
    /// </summary>
    public void Decript()
    {
        print("Decripting save file");
        File.Decrypt(path);
        print("Decripting done, reading file...");
    }
}
