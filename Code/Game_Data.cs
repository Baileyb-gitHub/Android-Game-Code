using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Data : MonoBehaviour
{
    [Header("Tracked Stats")]

    public int playerlevel;
    public int playerMoney;
    public float currentXP;
    public float targetXP;
    public List<float> levelXPGoals;

    [Header("hard Stats")]
    public int levelCap;

    // Start is called before the first frame update
    void Start()
    {
        // load exisitng save data if it exists 



        if(playerlevel == levelCap) 
        {
        }
        else 
        {
            targetXP = levelXPGoals[playerlevel - 1];
        }


        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelUp() 
    {
        playerlevel += 1;
        currentXP = 0;
        targetXP = levelXPGoals[playerlevel - 1];
    }

}
