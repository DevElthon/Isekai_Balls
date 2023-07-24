using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public void LoadingScene(){
        SceneLoad.scene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }
}
