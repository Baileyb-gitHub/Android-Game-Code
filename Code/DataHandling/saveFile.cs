using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class saveFile 
{
    public int playerlevel;
    public int playerMoney;
    public float currentXP;
    public float targetXP;
    public float highScore;

    public saveFile(Game_Data Game_Data)   // constructor stores values from the game_data input
    {
        playerlevel = Game_Data.playerlevel;
        playerMoney = Game_Data.playerMoney;
        currentXP = Game_Data.currentXP;
        targetXP = Game_Data.targetXP;
        highScore = Game_Data.highScore;

    }
}
