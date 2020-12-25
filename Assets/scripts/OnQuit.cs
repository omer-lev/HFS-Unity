using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuit : MonoBehaviour
{
    GameObject player;

    public void Start()
    {
        SaveSystem.SavePlayer(player);
    }

    public void OnApplicationQuit()
    {
        SaveSystem.LoadPlayer();
    }
}
