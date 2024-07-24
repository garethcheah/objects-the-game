using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefExample : MonoBehaviour
{
    public void SaveData()
    {
        PlayerPrefs.SetString("SAVE_DATA", "Add data here...");
    }

    public string LoadData()
    {
        string data = "";

        if (PlayerPrefs.HasKey("SAVE_DATA"))
        {
            data = PlayerPrefs.GetString("SAVE_DATA");
        }

        return data;
    }
}
