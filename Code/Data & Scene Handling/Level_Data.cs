using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Data : MonoBehaviour
{
    [Header("Logic")]
    public bool gameOver;


    [Header ("Ui References")]
    public float score;
    public float xpWon;
    public float xpCap;
    public float xpGainSeconds;
    private float xpGainSpeed;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    public GameObject gameActiveUI;
    [Header("Loss Ui ")]
    public Slider xpSlider;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI xpWonText;
    public TextMeshProUGUI xpStatusText;
    public TextMeshProUGUI levelText;
    

    [Header("Spawning")]
    public List<GameObject> enemySpawns;
    public List<GameObject> enemyTypes;
    public List<GameObject> powerUpSpawns;
    public List<GameObject> powerUpTypes;
    [Space]
    public float challengeValue;
    public int enemyCount;
    public int targetEnemyCount;
    public float enemyTimer;
    public float enemyTimerMax;
    [Space]
    public int powerUpCount;
    public int targetPowerUpCount;
    public float powerUpTimer;
    public float powerUpTimerMax;

    [Header("References")]
    public Game_Data gameData;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OnceASecond", 1.0f, 1.0f);
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
        updateSpawns();

        if(gameOver == true) 
        {
            updateLossUI();
        }
        
    }


    public void updateUI() 
    {
        scoreText.text = ("Score - " + score);
    }

    public void updateSpawns()
    {
        if(enemyCount < targetEnemyCount) 
        {
            enemyTimer -= 1 * Time.deltaTime;

            if(enemyTimer< 0.0f) 
            {
                int enemyIndex = Random.Range(0, enemyTypes.Count - 1);
                int spawnIndex = Random.Range(0, enemySpawns.Count - 1);

                Instantiate(enemyTypes[enemyIndex], enemySpawns[spawnIndex].transform.position, Quaternion.identity);  // spawns random enemy type at random spawn point;
                enemyCount += 1;
                enemyTimer = enemyTimerMax;  // reset timer
            }
            
        }


        if (powerUpCount < targetPowerUpCount)
        {
            powerUpTimer -= 1 * Time.deltaTime;  // if powerup is needed count down to next spawn

            if(powerUpTimer < 0.0f) 
            {
                int powerUpIndex = Random.Range(0, powerUpTypes.Count - 1);
                int spawnIndex = Random.Range(0, powerUpSpawns.Count - 1);

                Instantiate(powerUpTypes[powerUpIndex], powerUpSpawns[spawnIndex].transform.position, Quaternion.identity);  // spawns random power up type at random power up spawn point;
                powerUpCount += 1;
                powerUpTimer = powerUpTimerMax;  // reset timer
            }
           
        }



    }

    public void updateLossUI() 
    {
        if (xpWon > 0)   // XP BAR HANDLING
        {
            if(xpGainSpeed * Time.deltaTime > xpWon) 
            {
                gameData.currentXP += xpWon ;
                xpWon = 0;
               
            }
            else 
            {
                gameData.currentXP += xpGainSpeed * Time.deltaTime;
                xpWon -= xpGainSpeed * Time.deltaTime;
               
            }

            xpWon -= xpGainSpeed * Time.deltaTime;
            gameData.currentXP += xpGainSpeed * Time.deltaTime;
            xpSlider.value = gameData.currentXP / gameData.targetXP;
            Debug.Log("Did the xp bar  " + gameData.currentXP / gameData.targetXP);

            if(gameData.currentXP >= gameData.targetXP) 
            {
                gameData.levelUp();
                levelText.text = "LEVEL - " +gameData.playerlevel;
            }

        }


        xpStatusText.text = "" +Mathf.Round(gameData.currentXP) +"  /  " + gameData.targetXP + " XP";


    }

    void OnceASecond() 
    {
        addScore(1);
    }

    public void addScore(int scoreToAdd) 
    {
        if(gameOver == false) 
        {
            score += scoreToAdd;
        }
    }
    public void enemyDeath()
    {
        enemyCount -= 1;
    }

    public void gameLost()  // called once on game loss to display and set loss ui
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        gameActiveUI.SetActive(false);

       if(score > gameData.highScore) 
       {
            gameData.highScore = score;
       }

        xpWon = score / 10;
        xpWon = Mathf.Round(xpWon);
        xpSlider.value = gameData.currentXP / gameData.targetXP;
      //  Debug.Log("Starting XP = " + gameData.currentXP / gameData.targetXP );
        xpGainSpeed = xpWon / xpGainSeconds; //speed of after game xp set to take 5 seconds per level


        levelText.text = "LEVEL - " + gameData.playerlevel;
        endScoreText.text = "Score - " + score;
        xpWonText.text = "XP - " +xpWon;
    }

    public void finishXP()   // skips process bar and automatically applies remainign xp, called when player skips xp bar via scene changes eg retry or menu
    {
        gameOver = false;// stops extra xp added
        while(xpWon > 0) 
        {
            if (xpGainSpeed * Time.deltaTime > xpWon)
            {
                gameData.currentXP += xpWon;
                xpWon = 0;

            }
            else 
            {
                gameData.currentXP += xpGainSpeed * Time.deltaTime;
                xpWon -= xpGainSpeed * Time.deltaTime;
            }

          

            if (gameData.currentXP >= gameData.targetXP)
            {
                gameData.levelUp();
                levelText.text = "LEVEL - " + gameData.playerlevel;
            }
        }

    }



}
