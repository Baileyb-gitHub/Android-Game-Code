using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Data : MonoBehaviour
{
    [Header("Logic")]
    public bool gameOver;
    public string levelMode;
    public int levelNum;
    public float victoryThreshold;

    [Header("Stats")]
    public float score;
    public float scoreMultiplier;
    public float xpWon;
    public float xpCap;
    public float xpGainSeconds;
    public float xpGainSpeed;

    [Header(" UI References")] // references to Parents / chunks of ui for enabling and disabling
    public GameObject gameOverUI;
    public GameObject gameActiveUI;
    public GameObject powerUpUI;

    [Header ("Active UI ")]
    public TextMeshProUGUI scoreText;
    public bool powerUpActive;
    public float powerUpTimer;
    public TextMeshProUGUI powerUpText;
    public TextMeshProUGUI powerUpTimerText;
 

    [Header("Loss Ui ")]
    public Slider xpSlider;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI xpWonText;
    public TextMeshProUGUI xpStatusText;
    public TextMeshProUGUI levelText;


    [Header("Spawning / Object Handling")]
    public adaptiveDifficulty spawnHandler;

    [Header("References")]
    public Game_Data gameData;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OnceASecond", 1.0f, 1.0f);
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();


        if(gameOver == true) 
        {
            updateLossUI();
        }
        
    }


    public virtual void updateUI() 
    {
        scoreText.text = ("Score - " + score);
        if(powerUpActive == true) 
        {
            powerUpTimer -= 1.0f * Time.deltaTime;
            if (Mathf.Round(powerUpTimer) < 0.1) 
            {
                closePowerupUi();
            }
            else 
            {
                 powerUpTimerText.text =  Mathf.Round(powerUpTimer)  + " S";
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

    public virtual void OnceASecond() 
    {
        addScore(1);
    }

    public void addScore(int scoreToAdd) 
    {
        if(gameOver == false) 
        {
            score += scoreToAdd * scoreMultiplier;
        }
    }
    public virtual void enemyDeath()
    {
         spawnHandler.enemyCount -= 1;
        gameData.UpdateTotalStats(0, 1, 0, 0);
    }

    public virtual void gameLost()  // called once on game loss to display and set loss ui
    {

        xpWon = score / 10;  // calculates score for game
        xpWon = Mathf.Round(xpWon);

        gameData.UpdateTotalStats(1, 0, xpWon, score);
      
    


    gameOver = true;
        checkForCompletion();

        gameOverUI.SetActive(true);
        gameActiveUI.SetActive(false);

        cloudOnceServices.instance.submitScoreToLeaderboard(Mathf.RoundToInt(score));

       if (score > gameData.highScore) 
       {
            gameData.highScore = score;
            gameData.totalHighScores += 1;
            cloudOnceServices.instance.checkScoreAch(); //  check to see if player has unlocked high score based achievement
       }

       
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

    public virtual void checkForCompletion()
    {
        if (score >= victoryThreshold)
        {
            gameData.completeLevel(levelMode, levelNum);
        }
    }

    // POWERUP HANDLING

    public void setPowerupUi(string text, float timer)   // called by powerups on pickup to fill in ui info
    {
        powerUpText.text = text;
        powerUpTimer = timer;
        powerUpActive = true;
        powerUpUI.SetActive(true);
    }

    public void closePowerupUi()  // called by powerups to remove  ui once powerup used
    {
        powerUpText.text = null;
        powerUpTimer = 0.0f;
        powerUpActive = false;
        powerUpUI.SetActive(false);

    }



    

    public void callSaveData() 
    {
        gameData.saveData();
    }


}
