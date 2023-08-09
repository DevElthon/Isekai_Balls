using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public List<GameObject> biggerMenus = new List<GameObject>();
    public List<GameObject> lesserMenus = new List<GameObject>();

    public List<GameObject> locks1 = new List<GameObject>();

    public List<GameObject> skinLocks = new List<GameObject>();
    public List<GameObject> SkinButtons = new List<GameObject>();

    public TextMeshProUGUI coin;


    //Bigger Menus
    public void ActivateMenu(int menuPlus){
        biggerMenus[menuPlus].SetActive(true);
    }

    public void DeactivateMenu(int menuMinus){
        biggerMenus[menuMinus].SetActive(false);
    }

    //Lesser menus
    public void ActivateLesserMenu(int menuPlus){
        lesserMenus[menuPlus].SetActive(true);
    }

    public void DeactivateLesserMenu(int menuMinus){
        lesserMenus[menuMinus].SetActive(false);
    }

    public void ActiveSkin(int index){
        PlayerPrefs.SetInt("SetSkin", index);
    }

    private void LocksUpdate(){
        for(int i = 0; i < locks1.Count + 1; i++){
            if(PlayerPrefs.GetInt("Lock1") >= i && i >= 1){
                locks1[i - 1].SetActive(false);
            }
        }
    }

    private void SkinsLockUpdate(){
        for(int i = 1; i < skinLocks.Count + 1; i++){
            if(PlayerPrefs.GetInt("Skin" + i.ToString()) == 1){
                skinLocks[i-1].SetActive(false);
                SkinButtons[i - 1].SetActive(false);
            }
        }
    }

    private void Awake() {
        LocksUpdate();
        SkinsLockUpdate();
    }

    private void Update() {
        coin.text = PlayerPrefs.GetInt("Coins").ToString();
        SkinsLockUpdate();
    }
}