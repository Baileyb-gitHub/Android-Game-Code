using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class cloudOnceServices : MonoBehaviour
{

    public static cloudOnceServices instance;
    public Game_Data gameData;

    void Start()
    {
      
    }


    private void Awake()
    {
        testSingleton();
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
    }

    private void testSingleton() 
    {
        if(instance != null) 
        {
            Destroy(gameObject); return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void submitScoreToLeaderboard(int score) 
    {
        Leaderboards.EndlessHighscore.SubmitScore(score);
    }

    public void checkSkinAch() 
    {
        if(gameData.skinCount >= 10) 
        {
            awardFullWardrobe();
        }
        else  if (gameData.skinCount >= 5)
        {
            awardStylish();
        }
    }

    public void checkElimsAch() 
    {
        if (gameData.totalEnemiesDestroyed >= 500)
        {

            awardElimMaster();

        }
        else if (gameData.totalEnemiesDestroyed >= 250)
        {
            awardElimSkilled();
        }
        else if (gameData.totalEnemiesDestroyed >= 100)
        {
            awardElimAmateur();
        }
        else if (gameData.totalEnemiesDestroyed >= 50)
        {
            awardElimBeginner();
        }
    }

    public void checkLevelAch() 
    {
        if (gameData.playerlevel >= 30)
        {
            
            awardExperienced();
        }
        else if (gameData.playerlevel >= 15) 
        {         
            awardHalfWayThere();
        }
        else if (gameData.playerlevel >= 10)
        {
            awardDoubleDigits();
        }

    }

    public void checkGamesAch() 
    {
        if(gameData.totalGamesPlayed >= 100) 
        {
            awardComitted();

        }
        else if (gameData.totalGamesPlayed >= 50) 
        {
            awardBackForEvenMore();
         
        }
        else if (gameData.totalGamesPlayed >= 20)
        {
            
            awardBackForMore();
        }
    }
    public void checkScoreAch() 
    {
        if (gameData.totalHighScores >= 5)
        {
            awardSelfImprovement();
        }
        else if (gameData.totalHighScores >= 1) 
        {
            awardPersonalBest();
        }


    }

    public void awardBackForMore() 
    {
        if (Achievements.BackForMore.IsUnlocked == true) 
        { return; }

        else 
        {
            Achievements.BackForMore.Unlock();
        }
    }

   public void awardBackForEvenMore() 
   {
        if (Achievements.BackForEvenMore.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.BackForEvenMore.Unlock();
        }
   }

    public void awardComitted()
    {
        if (Achievements.Committed.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.Committed.Unlock();
        }
    }

    public void awardPersonalBest()
    {
        if (Achievements.PersonalBest.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.PersonalBest.Unlock();
        }
    }
    public void awardSelfImprovement()
    {
        if (Achievements.SelfImprovement.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.SelfImprovement.Unlock();
        }
    }

    public void awardDoubleDigits()
    {
        if (Achievements.DoubleDigits.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.DoubleDigits.Unlock();
        }
    }

    public void awardHalfWayThere()
    {
        if (Achievements.HalfWayThere.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.HalfWayThere.Unlock();
        }
    }

    public void awardExperienced()
    {
        if (Achievements.Experienced.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.Experienced.Unlock();
        }
    }

    public void awardStylish()
    {
        if (Achievements.Stylish.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.Stylish.Unlock();
        }
    }

    public void awardFullWardrobe()
    {
        if (Achievements.FullWardrobe.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.FullWardrobe.Unlock();
        }
    }

    public void awardElimBeginner()
    {
        if (Achievements.EliminationsBeginner.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.EliminationsBeginner.Unlock();
        }
    }

    public void awardElimAmateur()
    {
        if (Achievements.EliminationsAmateur.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.EliminationsAmateur.Unlock();
        }
    }

    public void awardElimSkilled()
    {
        if (Achievements.EliminationsSkilled.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.EliminationsSkilled.Unlock();
        }
    }

    public void awardElimMaster()
    {
        if (Achievements.EliminationsMaster.IsUnlocked == true)
        { return; }

        else
        {
            Achievements.EliminationsMaster.Unlock();
        }
    }
}
