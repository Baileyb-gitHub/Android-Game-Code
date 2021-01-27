using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Data_Elim : Level_Data
{
    [Header("ELIMINATION VARIABLES")]
    public int targetElims;
    public int currentElims;
    public TextMeshProUGUI eliminationText;
    public GameObject gameWonUI;
    public override void updateUI()
    {
        eliminationText.text = ("Eliminations Needed - " + (targetElims - currentElims));
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


    public override void enemyDeath()
    {
        spawnHandler.enemyCount -= 1;
        gameData.UpdateTotalStats(0, 1, 0, 0);
        currentElims += 1;
        if (currentElims >= targetElims)
        {
            gameData.completeLevel(levelMode, levelNum);
            Destroy(GameObject.FindWithTag("Player"));
            gameLost(); // triggers end victory
            CancelInvoke();
        }
    }

    public override void OnceASecond()
    {
        addScore(1);
       
    }

    public override void gameLost()  // called once on game loss to display and set loss ui
    {
        if(currentElims >= targetElims) 
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
