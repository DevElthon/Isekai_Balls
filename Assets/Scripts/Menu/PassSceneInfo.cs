using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassSceneInfo : MonoBehaviour
{
    public void GoToLoadScene(){
        SceneManager.LoadScene("LoadingScene");
    }
    public void PassScene(string scene){
        SceneLoad.scene = scene;
    }

    public void PassPhase(int phase){
        SceneLoad.phase = phase;
    }
    public void PassStage(int stages){
        SceneLoad.stages = stages;  
    }
}
