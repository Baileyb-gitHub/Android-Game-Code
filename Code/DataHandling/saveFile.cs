using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class saveFile 
{
    [Header("Core Stats")]
    public int playerlevel;
    public int playerMoney;
    public float currentXP;
    public float targetXP;
    public float highScore;

    [Header("Tracking Stats")]
    public int totalGamesPlayed;
    public int totalEnemiesDestroyed;
    public float totalScore;
    public float totalXP;
    public int totalHighScores;

    [Header("Settings Options")]
    public float gameVolume;

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


    public saveFile(Game_Data Game_Data)   // constructor stores values from the game_data input
    {
        //CoreStats
        playerlevel = Game_Data.playerlevel;
        playerMoney = Game_Data.playerMoney;
        currentXP = Game_Data.currentXP;
        targetXP = Game_Data.targetXP;
        highScore = Game_Data.highScore;

        //Tracking Stats
        totalEnemiesDestroyed = Game_Data.totalEnemiesDestroyed;
        totalScore = Game_Data.totalScore;
        totalGamesPlayed = Game_Data.totalGamesPlayed;
        totalXP = Game_Data.totalXP;
        totalHighScores = Game_Data.totalHighScores;

        //Settings Options
        gameVolume = Game_Data.gameVolume;

        //Endless progress
        completedEndlessLevel1 = Game_Data.completedEndlessLevel1;
        completedEndlessLevel2 = Game_Data.completedEndlessLevel2; 
        completedEndlessLevel3 = Game_Data.completedEndlessLevel3;
        completedEndlessLevel4 = Game_Data.completedEndlessLevel4;
        completedEndlessLevel5 = Game_Data.completedEndlessLevel5;

        //Survival progress
        completedSurvivalLevel1 = Game_Data.completedSurvivalLevel1;
        completedSurvivalLevel2 = Game_Data.completedSurvivalLevel2;
        completedSurvivalLevel3 = Game_Data.completedSurvivalLevel3;
        completedSurvivalLevel4 = Game_Data.completedSurvivalLevel4;
        completedSurvivalLevel5 = Game_Data.completedSurvivalLevel5;

        //Elimination progress
        completedEliminationLevel1 = Game_Data.completedEliminationLevel1;
        completedEliminationLevel2 = Game_Data.completedEliminationLevel2;
        completedEliminationLevel3 = Game_Data.completedEliminationLevel3;
        completedEliminationLevel4 = Game_Data.completedEliminationLevel4;
        completedEliminationLevel5 = Game_Data.completedEliminationLevel5;

        //Skin Unlocks
        skin1Unlocked = Game_Data.skin1Unlocked;
        skin2Unlocked = Game_Data.skin2Unlocked;
        skin3Unlocked = Game_Data.skin3Unlocked;
        skin4Unlocked = Game_Data.skin4Unlocked;
        skin5Unlocked = Game_Data.skin5Unlocked;
        skin6Unlocked = Game_Data.skin6Unlocked;
        skin7Unlocked = Game_Data.skin7Unlocked;
        skin8Unlocked = Game_Data.skin8Unlocked;
        skin9Unlocked = Game_Data.skin9Unlocked;
        skin10Unlocked = Game_Data.skin10Unlocked;
        skinCount = Game_Data.skinCount;
        skinOfChoice = Game_Data.skinOfChoice;
    }
}
