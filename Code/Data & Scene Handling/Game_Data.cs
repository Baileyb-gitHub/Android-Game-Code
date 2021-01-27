using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



public class Game_Data : MonoBehaviour
{
    [Header("Core Stats")]

    public int playerlevel;
    public int playerMoney;
    public float currentXP;
    public float targetXP;
    public List<float> levelXPGoals;
    public float highScore;
    public List<Material> playerSkins;

    [Header("Tracking Stats")]
    public int totalGamesPlayed;
    public int totalEnemiesDestroyed;
    public float totalScore;
    public float totalXP;
    public int totalHighScores;

    [Header("Endless progress")]
    public bool completedEndlessLevel1;
    public bool completedEndlessLevel2;
    public bool completedEndlessLevel3;
    public bool completedEndlessLevel4;
    public bool completedEndlessLevel5;
    [Header("Survival progress")]
    public bool completedSurvivalLevel1;
    public bool completedSurvivalLevel2;
    public bool completedSurvivalLevel3;
    public bool completedSurvivalLevel4;
    public bool completedSurvivalLevel5;
    [Header("Elimination progress")]
    public bool completedEliminationLevel1;
    public bool completedEliminationLevel2;
    public bool completedEliminationLevel3;
    public bool completedEliminationLevel4;
    public bool completedEliminationLevel5;

    [Header("Skin Unlocks")]
    public bool skin1Unlocked;
    public bool skin2Unlocked;
    public bool skin3Unlocked;
    public bool skin4Unlocked;
    public bool skin5Unlocked;
    public bool skin6Unlocked;
    public bool skin7Unlocked;
    public bool skin8Unlocked;
    public bool skin9Unlocked;
    public bool skin10Unlocked;
    public int skinCount;
    public int skinOfChoice;

    [Header("Achievement Unlocks")]
    public bool achievement1;
    

    [Header("Settings Options")]
    public float gameVolume;

    [Header("hard Stats")]
    public int levelCap;

    [Header("References")]
    public AudioSource audioPlayer;

    [Header("Debugging")]
    public bool mouseMode; // enables or disables mouse movement

    // Start is called before the first frame update
    void Start()
    {
        loadData();  // loads any previously saved gameData

        // load exisitng save data if it exists 
        audioPlayer = gameObject.GetComponent<AudioSource>();


        if (playerlevel == levelCap) 
        {
        }
        else 
        {
            targetXP = levelXPGoals[playerlevel - 1];
        }

        skinUnlockCheck();
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelUp() 
    {
        audioPlayer.Play();
        playerlevel += 1;
        currentXP = 0;
        targetXP = levelXPGoals[playerlevel - 1];

        cloudOnceServices.instance.checkLevelAch();  // checks if level up unlocks an achievement
    }

    public void saveData() 
    {
        saveSystem.saveData(gameObject.GetComponent<Game_Data>());
    }

    public void ResetData()
    {
       


       playerlevel = 1;
       playerMoney = 0;
       currentXP = 0;
       targetXP = levelXPGoals[0];
       highScore = 0;

       totalEnemiesDestroyed = 0;
       totalScore = 0;
       totalGamesPlayed = 0;
       totalXP = 0;
       totalHighScores= 0;

        gameVolume = 1;

        // level progress

       completedEndlessLevel1 = false;
       completedEndlessLevel2 = false;
       completedEndlessLevel3 = false;
       completedEndlessLevel4 = false;
       completedEndlessLevel5 = false;

       completedSurvivalLevel1 = false;
       completedSurvivalLevel2 = false;
       completedSurvivalLevel3 = false;
       completedSurvivalLevel4 = false;
       completedSurvivalLevel5 = false;

        completedEliminationLevel1 = false;
        completedEliminationLevel2 = false;
        completedEliminationLevel3 = false;
        completedEliminationLevel4 = false;
        completedEliminationLevel5 = false;



        skin2Unlocked = false;
        skin3Unlocked = false;
        skin4Unlocked = false;
        skin5Unlocked = false;
        skin6Unlocked = false;
        skin7Unlocked = false;
        skin8Unlocked = false;
        skin9Unlocked = false;
        skin10Unlocked = false;
        skinCount = 1;
        skinOfChoice = 1;

        saveSystem.saveData(gameObject.GetComponent<Game_Data>());

 
    }

    public void loadData()
    {
        saveFile data = saveSystem.loadData();

        if(data == null) 
        {
        
        }
        else 
        {
            playerlevel = data.playerlevel;
            playerMoney = data.playerMoney;
            currentXP = data.currentXP;
            targetXP = data.targetXP;
            highScore = data.highScore;

            totalEnemiesDestroyed = data.totalEnemiesDestroyed;
            totalScore = data.totalScore;
            totalGamesPlayed = data.totalGamesPlayed;
            totalXP = data.totalXP;
            totalHighScores = data.totalHighScores;

            gameVolume = data.gameVolume;

            //Endless progress
            completedEndlessLevel1 = data.completedEndlessLevel1;
            completedEndlessLevel2 = data.completedEndlessLevel2;
            completedEndlessLevel3 = data.completedEndlessLevel3;
            completedEndlessLevel4 = data.completedEndlessLevel4;
            completedEndlessLevel5 = data.completedEndlessLevel5;

            //Survival progress
            completedSurvivalLevel1 = data.completedSurvivalLevel1;
            completedSurvivalLevel2 = data.completedSurvivalLevel2;
            completedSurvivalLevel3 = data.completedSurvivalLevel3;
            completedSurvivalLevel4 = data.completedSurvivalLevel4;
            completedSurvivalLevel5 = data.completedSurvivalLevel5;

            //Elimination progress
            completedEliminationLevel1 = data.completedEliminationLevel1;
            completedEliminationLevel2 = data.completedEliminationLevel2;
            completedEliminationLevel3 = data.completedEliminationLevel3;
            completedEliminationLevel4 = data.completedEliminationLevel4;
            completedEliminationLevel5 = data.completedEliminationLevel5;

            //Skin Unlocks
            skin1Unlocked = data.skin1Unlocked;
            skin2Unlocked = data.skin2Unlocked;
            skin3Unlocked = data.skin3Unlocked;
            skin4Unlocked = data.skin4Unlocked;
            skin5Unlocked = data.skin5Unlocked;
            skin6Unlocked = data.skin6Unlocked;
            skin7Unlocked = data.skin7Unlocked;
            skin8Unlocked = data.skin8Unlocked;
            skin9Unlocked = data.skin9Unlocked;
            skin10Unlocked = data.skin10Unlocked;
            skinCount =  data.skinCount;
            skinOfChoice = data.skinOfChoice;
        }

      
    }



    public void UpdateTotalStats(int gameUpdate, int killsUpdate, float xpUpdate, float scoreUpdate) // adds a score of current game to the tracked total
    {
        totalGamesPlayed += gameUpdate;
        totalScore += scoreUpdate;
        totalXP += xpUpdate;
        totalEnemiesDestroyed += killsUpdate;

        cloudOnceServices.instance.checkGamesAch(); //  check to see if player has unlocked total games  based achievement
        cloudOnceServices.instance.checkElimsAch(); //  check to see if player has unlocked total elimination  based achievement
    }

    public void completeLevel(string modeName, int LevelNum) // sets corresponding level status to complete
    {
       if(modeName == "Endless") 
       {
            switch (LevelNum)
            {
                case 1:
                    completedEndlessLevel1 = true;
                    break;
                case 2:
                    completedEndlessLevel2 = true;
                    break;
                case 3:
                    completedEndlessLevel3 = true;
                    break;
                case 4:
                    completedEndlessLevel4 = true;
                    break;
                case 5:
                    completedEndlessLevel5 = true;
                    break;
            }
       }
       else if(modeName == "Survival")
       {
            switch (LevelNum)
            {
                case 1:
                    completedSurvivalLevel1 = true;
                    break;
                case 2:
                    completedSurvivalLevel2 = true;
                    break;
                case 3:
                    completedSurvivalLevel3 = true;
                    break;
                case 4:
                    completedSurvivalLevel4 = true;
                    break;
                case 5:
                    completedSurvivalLevel5 = true;
                    break;
            }
       }
        else if(modeName == "Elimination")
        {
            switch (LevelNum)
            {
                case 1:
                    completedEliminationLevel1 = true;
                    break;
                case 2:
                    completedEliminationLevel2 = true;
                    break;
                case 3:
                    completedEliminationLevel3 = true;
                    break;
                case 4:
                    completedEliminationLevel4 = true;
                    break;
                case 5:
                    completedEliminationLevel5 = true;
                    break;
            }
        }
        else{ Debug.Log("Error, incorrect level type given, could not unlock relevent next level"); }


    }

    public void skinUnlockCheck() 
    {
        skin1Unlocked = true;

        if (playerlevel > 4)
        {
            if(skin2Unlocked != true)  // call check for skin achievements here ?
            {
                skin2Unlocked = true;
                skinCount += 1;
            }
        
        }

        if (playerlevel > 9)
        {   
            if(skin3Unlocked != true) 
            {
                skin3Unlocked = true;
                skinCount += 1;
            }
           
        }

        if (playerlevel > 14)
        {
            if (skin4Unlocked != true)
            {
                skin4Unlocked = true;
                skinCount += 1;
            }
        }

        if (playerlevel > 19)
        {
            if (skin5Unlocked != true)
            {
                skin5Unlocked = true;
                skinCount += 1;
            }
        }

        if (playerlevel > 24)
        {
            if (skin6Unlocked != true)
            {
                skin6Unlocked = true;
                skinCount += 1;
            }
        }

        if (playerlevel > 29)
        {
            if (skin7Unlocked != true)
            {
                skin7Unlocked = true;
                skinCount += 1;
            }
        }

        if (completedSurvivalLevel1 == true && completedSurvivalLevel2 == true && completedSurvivalLevel3 == true && completedSurvivalLevel4 == true && completedSurvivalLevel5 == true)
        {
            if (skin8Unlocked != true)
            {
                skin8Unlocked = true;
                skinCount += 1;
            }
        }

        if (completedEliminationLevel1 == true && completedEliminationLevel2 == true && completedEliminationLevel3 == true && completedEliminationLevel4 == true && completedEliminationLevel5 == true)
        {
            if (skin9Unlocked != true)
            {
                skin9Unlocked = true;
                skinCount += 1;
            }
        }

        if (skinCount >= 9)
        {
            if (skin10Unlocked != true)
            {
                skin10Unlocked = true;
                skinCount += 1;
            }          
        }
        cloudOnceServices.instance.checkSkinAch();
    }

    
}
