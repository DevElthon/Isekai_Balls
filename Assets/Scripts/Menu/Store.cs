using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    private int strengthValue;
    private int defenseValue;
    private int coinValue;
    private int skinBaseValue;

    [SerializeField]
    private TextMeshProUGUI str, def, coin;

    [SerializeField]
    private TextMeshProUGUI priceStr, priceDef, priceCoin;


    //Skills Logic
    public void BuyStrength(){
        if(PlayerPrefs.GetInt("Coins") >= strengthValue){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - strengthValue);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
        }
    }

    public void BuyDefense(){
        if(PlayerPrefs.GetInt("Coins") >= defenseValue){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - defenseValue);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
        }
    }

    public void BuyCoinLVL(){
        if(PlayerPrefs.GetInt("Coins") >= coinValue){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - coinValue);
            PlayerPrefs.SetInt("CoinLvl", PlayerPrefs.GetInt("CoinLvl") + 1);
        }
    }

    public void UpdateSkillsLVL(){
        str.text = "Lvl " + PlayerPrefs.GetInt("Strength");
        def.text = "Lvl " + PlayerPrefs.GetInt("Defense");
        coin.text = "Lvl " + PlayerPrefs.GetInt("CoinLvl");
    }

    public void UpdatePrice(){
        strengthValue = 100 + PlayerPrefs.GetInt("Strength") * 50;
        defenseValue = 100 + PlayerPrefs.GetInt("Defense") * 50;
        coinValue = 100 + PlayerPrefs.GetInt("CoinLvl") * 50;
        
        priceStr.text = strengthValue.ToString();
        priceDef.text = defenseValue.ToString();
        priceCoin.text = coinValue.ToString();
    }
    //Skills logic end

    //Skins logic
    public void BuySkin(int index){
        skinBaseValue = 200 + index * 100;
        if(PlayerPrefs.GetInt("Coins") >= skinBaseValue){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - skinBaseValue);
            PlayerPrefs.SetInt("Skin"+index.ToString(), 1);
            PlayerPrefs.SetInt("SetSkin", index);
        }
    }

    private void Update() {
        UpdateSkillsLVL();
        UpdatePrice();
    }
}
