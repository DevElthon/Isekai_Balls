using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    private Gameplay instance;

    [SerializeField]
    private TextMeshProUGUI coinsPlus;
    [SerializeField]
    private TextMeshProUGUI phaseComplete;

    private void Awake() {
        instance = Gameplay.instance;
    }

    public void Pause(){
        Time.timeScale=0f;
        pauseMenu.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void LoadingScene(){
        Time.timeScale = 1f;
        SceneLoad.scene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }

    private void Update() {
        phaseComplete.text = "PHASE " + instance.phase.ToString() + " COMPLETE !";
        coinsPlus.text = "+" + (instance.coinAmount + (instance.phase * 5) + PlayerPrefs.GetInt("CoinLvl") * 5).ToString();
    }

    public void GoNext(){
        instance.NextPhase();
    }
}
