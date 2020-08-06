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


    void Start()  // Start is called before the first frame update
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        gameData.currentXP = Mathf.Round(gameData.currentXP);

        levelText.text = "Level - " + gameData.playerlevel;
        xpText.text = " " + gameData.currentXP +" / " + gameData.targetXP + " XP";
        highScoreText.text = "High Score - " + gameData.highScore;

        xpSlider.value = gameData.currentXP / gameData.targetXP;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
