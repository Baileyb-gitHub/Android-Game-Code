using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



public class Game_Data : MonoBehaviour
{
    [Header("Tracked Stats")]

    public int playerlevel;
    public int playerMoney;
    public float currentXP;
    public float targetXP;
    public List<float> levelXPGoals;
    public float highScore;
    public Material playerMaterial;

    [Header("hard Stats")]
    public int levelCap;

    [Header("References")]
    public AudioSource audioPlayer;

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
    }

    public void saveData() 
    {
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
        }

      
    }

}
