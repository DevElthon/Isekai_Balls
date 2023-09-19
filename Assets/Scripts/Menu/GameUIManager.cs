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

    [SerializeField]
    private GameObject stageCounter1;
    [SerializeField]
    private GameObject[] stageCounter2;
    [SerializeField]
    private GameObject[] stageCounter3;

    private void Awake() {
        instance = Gameplay.instance;
        StopCounting();
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
        StageCounting();
        phaseComplete.text = "PHASE " + instance.phase.ToString() + " COMPLETE !";
        coinsPlus.text = "+" + (instance.coinAmount + (instance.phase * 5) + PlayerPrefs.GetInt("CoinLvl") * 5).ToString();
    }

    public void GoNext(){
        instance.NextPhase();
    }

    private void StageCounting(){
        // Debug.Log(SceneLoad.phase);
        // Debug.Log(Gameplay.instance.enemyCounter);
        switch(SceneLoad.phase){
            case < 4:
                if(Gameplay.instance.enemyCounter == 1)
                    stageCounter1.SetActive(true);
                break;

            case < 7:
                if(Gameplay.instance.enemyCounter >= SceneLoad.stages * SceneLoad.stages){
                    stageCounter2[1].gameObject.SetActive(true);
                    }
                    else if(Gameplay.instance.enemyCounter == 2){
                        stageCounter2[0].gameObject.SetActive(true);
                    }
                break;

            case < 10:
                if(Gameplay.instance.enemyCounter >= SceneLoad.stages * SceneLoad.stages){
                        stageCounter3[2].gameObject.SetActive(true);
                    }
                    else{
                        if(Gameplay.instance.enemyCounter == 3){
                            stageCounter3[0].gameObject.SetActive(true);
                        }
                        else if(Gameplay.instance.enemyCounter == 6){
                            stageCounter3[1].gameObject.SetActive(true);
                        }
                    }
                break;

            case 10:
                if(Gameplay.instance.enemyCounter == 1)
                    stageCounter1.SetActive(true);
                break;
        }
    }

    private void StopCounting(){
        stageCounter1.SetActive(false);
        for(int i = 0; i < stageCounter2.Length; i++){
            stageCounter2[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < stageCounter3.Length; i++){
            stageCounter3[i].gameObject.SetActive(false);
        }
    }
}
