using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> biggerMenus = new List<GameObject>();
    public List<GameObject> lesserMenus = new List<GameObject>();


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
}