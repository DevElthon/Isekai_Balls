using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;
    private int phase;

    [Header("Player Spawn")]
    public List<GameObject> playerSpawnPoints = new List<GameObject>();
    [SerializeField]
    private GameObject player;

    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        phase = SceneLoad.phase;
    }

    void Start()
    {
        CurrentPhase(phase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CurrentPhase(int phase){
        Instantiate(player, playerSpawnPoints[phase - 1].transform.position, Quaternion.identity);
    }
}
