using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menu_Data : MonoBehaviour
{
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI highScoreText;
    public Slider xpSlider;
    //public TextMeshProUGUI xpWonText;
    public Game_Data gameData;  
    [Header ("Total Stats")]
    public TextMeshProUGUI totalGamesText;
    public TextMeshProUGUI totalEnemiesDestroyedText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI totalXPText;

    void Start()  // Start is called before the first frame update
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();

        refreshUIElements();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refreshUIElements() 
    {
        gameData.currentXP = Mathf.Round(gameData.currentXP);

        levelText.text = "Level - " + gameData.playerlevel;
        xpText.text = " " + gameData.currentXP + " / " + gameData.targetXP + " XP";
        highScoreText.text = "High Score - " + gameData.highScore;
        xpSlider.value = gameData.currentXP / gameData.targetXP;


        totalGamesText.text = "Total Games Played - " + gameData.totalGamesPlayed;
        totalEnemiesDestroyedText.text = "Total Enemies Destroyed  - " + gameData.totalEnemiesDestroyed;
        totalScoreText.text = "Total Score Earned - " + gameData.totalScore;
        totalXPText.text = "Total XP Earned - " + gameData.totalXP;


    }

}
