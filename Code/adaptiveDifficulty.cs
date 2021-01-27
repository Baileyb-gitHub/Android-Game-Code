using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class adaptiveDifficulty : MonoBehaviour
{

    [Header("Spawning / Object Refrences")]
    public List<GameObject> enemySpawns;
    public List<GameObject> enemyTypes;
    public List<GameObject> powerUpSpawns;
    public List<GameObject> powerUpTypes;
    [Space]
    [Header("Enemy Data")]
    public int enemyCount;
    public int targetEnemyCount;
    public float enemyTimer;
    public float enemyTimerMax;
    [Space]
    [Header("Power Up Data")]
    public int powerUpCount;
    public int targetPowerUpCount;
    public float powerUpSpawnTimer;
    public float powerUpSpawnTimerMax;
    [Space]
    [Header("Scale Settings")]
    public float timeCounter;
    public int challengeLevelIndex;
    public List<float> challengeCheckpoint;
    public List<int> enemyToAdd;
    public List<int> powerUpsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        challengeLevelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (enemyCount < targetEnemyCount)
        {
            enemyTimer -= 1 * Time.deltaTime;

            if (enemyTimer < 0.0f)
            {
                int enemyIndex = Random.Range(0, enemyTypes.Count);
                int spawnIndex = Random.Range(0, enemySpawns.Count - 1);

                Instantiate(enemyTypes[enemyIndex], enemySpawns[spawnIndex].transform.position, Quaternion.identity);  // spawns random enemy type at random spawn point;
                enemyCount += 1;
                enemyTimer = enemyTimerMax;  // reset timer
            }

        }


        if (powerUpCount < targetPowerUpCount)
        {
            powerUpSpawnTimer -= 1 * Time.deltaTime;  // if powerup is needed count down to next spawn

            if (powerUpSpawnTimer < 0.0f)
            {
                int powerUpIndex = Random.Range(0, powerUpTypes.Count - 1);
                int spawnIndex = Random.Range(0, powerUpSpawns.Count - 1);

                Instantiate(powerUpTypes[powerUpIndex], new Vector3 (powerUpSpawns[spawnIndex].transform.position.x , powerUpSpawns[spawnIndex].transform.position.y, powerUpSpawns[spawnIndex].transform.position.z - 1), Quaternion.identity);  // spawns random power up type at random power up spawn point;
                powerUpCount += 1;
                powerUpSpawnTimer = powerUpSpawnTimerMax;  // reset timer
            }

        }




        timeCounter += 1 * Time.deltaTime;
        if(timeCounter > challengeCheckpoint[challengeLevelIndex]) 
        {
            targetEnemyCount += enemyToAdd[challengeLevelIndex];
            targetPowerUpCount += powerUpsToAdd[challengeLevelIndex];
            timeCounter = 0f;
            challengeLevelIndex += 1;
        }


    }
}
