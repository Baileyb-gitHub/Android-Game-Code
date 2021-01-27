using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Data_Time : Level_Data
{
    [Header("TIME TRIAL VARIABLES")]
    public double survivalTimer;
    public TextMeshProUGUI TimeText;

    void Start()
    {
        InvokeRepeating("OnceASecond", 1.0f, 1.0f);
        InvokeRepeating("timeCheck", 0.1f, 0.1f);
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        scoreMultiplier = 1;
    }
    // Start is called before the first frame update
    public override void updateUI()
    {
        if(gameOver != true) 
        {
            survivalTimer -= 1 * Time.deltaTime;
            TimeText.text = ("Time Remaining - " + System.Math.Round(survivalTimer, 1));
        }
      

        

        if (powerUpActive == true)
        {
            powerUpTimer -= 1.0f * Time.deltaTime;
            if (Mathf.Round(powerUpTimer) < 0.1)
            {
                closePowerupUi();
            }
            else
            {
                powerUpTimerText.text = Mathf.Round(powerUpTimer) + " S";
            }

        }
    }

    public void timeCheck() 
    {
        if (survivalTimer <= 0.0f)
        {
            CancelInvoke();
            gameData.completeLevel(levelMode, levelNum);
            Debug.Log(levelMode + levelNum);
            Destroy(GameObject.FindWithTag("Player"));
            gameLost();

        }
    }
    public override void OnceASecond()
    {
        addScore(1);
       
 
    }


public override void gameLost()  // called once on game loss to display and set loss ui
    {
        gameOver = true;
        if (survivalTimer <= 0.0f)
        {

            endScoreText.text = "Mission Complete";
        }
        else
        {
            endScoreText.text = "Mission Failed";
        }


        xpWon = score / 10;  // calculates score for game
        xpWon = Mathf.Round(xpWon);

        gameData.UpdateTotalStats(1, 0, xpWon, score);

        gameOver = true;


        gameOverUI.SetActive(true);
        gameActiveUI.SetActive(false);




        xpSlider.value = gameData.currentXP / gameData.targetXP;
        //  Debug.Log("Starting XP = " + gameData.currentXP / gameData.targetXP );
        xpGainSpeed = xpWon / xpGainSeconds; //speed of after game xp set to take 5 seconds per level


        levelText.text = "LEVEL - " + gameData.playerlevel;
        xpWonText.text = "XP - " + xpWon;
    }


}
