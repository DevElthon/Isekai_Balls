using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;
    public int phase;
    public int stages, enemyCounter;
    public int coinAmount;

    [Header("Player Spawn")]
    public List<GameObject> playerSpawnPoints = new List<GameObject>();
    [Header("Enemy Spawn")]
    public List<GameObject> enemySpawnPoints = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField]
    private GameObject player;
    private GameObject currentPlayer;

    [SerializeField]
    private GameObject nextPhasePanel;

    private void Awake() {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

        phase = SceneLoad.phase;
        stages = SceneLoad.stages;
    }

    void Start()
    {
        CurrentPhase(phase, stages);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CurrentPhase(int phase, int stages){
        this.stages = stages;
        currentPlayer = Instantiate(player, playerSpawnPoints[phase - 1].transform.position, Quaternion.identity);
        SpawnEnemies();
    }
    private void SpawnEnemies(){
        Instantiate(enemies[phase - 1], enemySpawnPoints[phase - 1].transform.position, Quaternion.identity);
    }

    private void StageCompute(int counter){
        if(enemyCounter >= stages * stages){
            switch (phase){
                case < 3:
                    SceneLoad.phase += 1;
                    SceneLoad.stages = 1;
                    break;
                case < 6:
                    SceneLoad.phase += 1;
                    SceneLoad.stages = 2;
                    break;
                case < 9:
                    SceneLoad.phase += 1;
                    SceneLoad.stages = 3;
                    break;
                case 9:
                    SceneLoad.phase += 1;
                    SceneLoad.stages = 1;
                    break;
                case 10:
                    UpdateMapData();
                    SceneLoad.scene = "Menu";
                    break;
            }

            UpdateMapData();

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coinAmount + (phase * 5)  + PlayerPrefs.GetInt("CoinLvl") * 5);

            Time.timeScale = 0f;
            nextPhasePanel.SetActive(true);
        }

        else if(enemyCounter % stages == 0 && enemyCounter >= stages && enemyCounter < stages * stages){
            Debug.Log(enemyCounter);
            SpawnEnemies();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")){
            enemyCounter += 1;
            StageCompute(enemyCounter);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Player")){
            Destroy(currentPlayer);
            SceneManager.LoadScene("LoadingScene");
        }
    }

    public void NextPhase(){
            enemyCounter = 0;
            Time.timeScale = 1f;
            SceneManager.LoadScene("LoadingScene");
    }

    public void UpdateMapData(){
        if(PlayerPrefs.GetInt("Map1Counter") < phase){
                PlayerPrefs.SetInt("Map1Counter",PlayerPrefs.GetInt("Map1Counter")  + 1);
                PlayerPrefs.SetInt("Lock1",PlayerPrefs.GetInt("Lock1") + 1);

                Debug.Log(PlayerPrefs.GetInt("Lock1"));
                Debug.Log(PlayerPrefs.GetInt("MapCounter"));
            }
    }
}
