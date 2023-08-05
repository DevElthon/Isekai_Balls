using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Status data
        if (!PlayerPrefs.HasKey("Strength"))
            PlayerPrefs.SetInt("Strength", 0);

        if (!PlayerPrefs.HasKey("Defense"))
            PlayerPrefs.SetInt("Defense", 0);
        
        if (!PlayerPrefs.HasKey("CoinLvl"))
            PlayerPrefs.SetInt("CoinLvl", 0);

        //Collectable data
        if (!PlayerPrefs.HasKey("Coins"))
            PlayerPrefs.SetInt("Coins", 0);
        
        //Skins
        if (!PlayerPrefs.HasKey("Skin1"))
            PlayerPrefs.SetInt("Skin1", 0);
        if (!PlayerPrefs.HasKey("Skin2"))
            PlayerPrefs.SetInt("Skin2", 0);
        if (!PlayerPrefs.HasKey("Skin3"))
            PlayerPrefs.SetInt("Skin3", 0);
        if (!PlayerPrefs.HasKey("Skin4"))
            PlayerPrefs.SetInt("Skin4", 0);
        if (!PlayerPrefs.HasKey("Skin5"))
            PlayerPrefs.SetInt("Skin5", 0);
        if (!PlayerPrefs.HasKey("Skin6"))
            PlayerPrefs.SetInt("Skin6", 0);

        //Map 1
        if (!PlayerPrefs.HasKey("Map1Timer"))
            PlayerPrefs.SetFloat("Map1Timer", 0);
        if (!PlayerPrefs.HasKey("Map1Counter"))
            PlayerPrefs.SetInt("Map1Counter", 0);

        if (!PlayerPrefs.HasKey("Lock1"))
            PlayerPrefs.SetInt("Lock1", 0);
    }
}
