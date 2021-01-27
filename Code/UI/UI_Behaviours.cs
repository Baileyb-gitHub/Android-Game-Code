using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using CloudOnce;

public class UI_Behaviours : MonoBehaviour
{

    public Slider volumeSlider;
    public Game_Data gameData;
    public AudioListener audioListener;
   
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        refreshSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leaderboardDisplay() 
    {
        if (Cloud.IsSignedIn)
        {
            Cloud.Leaderboards.ShowOverlay();
        }
        else
        {

            Cloud.SignIn();
        }
    }
    public void leaderboardDisplayRisk()
    {
        Cloud.Leaderboards.ShowOverlay();
    }
    // LOAD AND UNLOAD UI ELEEMENTS
    public void activateObject(GameObject objectReference)
    {
        objectReference.SetActive(true);
    }
    public void deActivateObject(GameObject objectReference)
    {
        objectReference.SetActive(false);
    }


    //SCENE MANAGMENT

    public void loadScene(string sceneToLoad) 
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void loadCurrentScene()  // reloads current scene
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    // DATA HANDLING FUNCTIONS

    public void exitAplication()
    {
        Application.Quit();
    }

    public void saveApplicationData()
    {
     
        gameData.saveData();
    }

    public void resetApplicationData()
    {
        
        gameData.ResetData();
    }
    public void refreshUnlockedSkins()
    {

        gameData.skinUnlockCheck();
    }

    // VALUE SETTING

    public void setVolume() 
    {
        gameData.gameVolume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
    }

    public void refreshSettings() // sets up  ui to display current stored settings
    {
        volumeSlider.value = gameData.gameVolume; ;
    }

    public void analyticsStatsButton() // sets up  ui to display current stored settings
    {
        Analytics.CustomEvent("Stats Button Pressed");
    }

    public void testAch1() // sets up  ui to display current stored settings
    {
        cloudOnceServices.instance.awardBackForMore();
    }
}
