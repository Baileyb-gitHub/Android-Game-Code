using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUnlocker : MonoBehaviour
{

    public Game_Data gameData;
    public GameObject[]  endlessBlockers;
    public GameObject[] survivalBlockers;
    public GameObject[] eliminationBlockers;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();

    }

    public void lockLevels()  // locks appropriate levels in level select menu based on player progress
    {

        if (gameData.completedEndlessLevel1 == true)
        {
            endlessBlockers[0].SetActive(false);
        }
        else 
        {
            endlessBlockers[0].SetActive(true);
        }


        if (gameData.completedEndlessLevel2 == true)
        {
            endlessBlockers[1].SetActive(false); 
        }
        else
        {
            endlessBlockers[1].SetActive(true);
        }

        if (gameData.completedEndlessLevel3 == true)
        {
            endlessBlockers[2].SetActive(false); 
        }
        else
        {
            endlessBlockers[2].SetActive(true);
        }

        if (gameData.completedEndlessLevel4 == true)
        {
            endlessBlockers[3].SetActive(false); 
        }
        else
        {
            endlessBlockers[3].SetActive(true);
        }




        if (gameData.completedSurvivalLevel1 == true)
        {
            survivalBlockers[0].SetActive(false);
        }
        else
        {
            survivalBlockers[0].SetActive(true);
        }

        if (gameData.completedSurvivalLevel2 == true)
        {
            survivalBlockers[1].SetActive(false);
        }
        else
        {
            survivalBlockers[1].SetActive(true);
        }

        if (gameData.completedSurvivalLevel3 == true)
        {
            survivalBlockers[2].SetActive(false);
        }
        else
        {
            survivalBlockers[2].SetActive(true);
        }

        if (gameData.completedSurvivalLevel4 == true)
        {
            survivalBlockers[3].SetActive(false);
        }
        else
        {
            survivalBlockers[3].SetActive(true);
        }


        if (gameData.completedEliminationLevel1 == true)
        {
            eliminationBlockers[0].SetActive(false);
        }
        else
        {
            eliminationBlockers[0].SetActive(true);
        }

        if (gameData.completedEliminationLevel2 == true)
        {
            eliminationBlockers[1].SetActive(false);
        }
        else
        {
            eliminationBlockers[1].SetActive(true);
        }

        if (gameData.completedEliminationLevel3 == true)
        {
            eliminationBlockers[2].SetActive(false);
        }
        else
        {
            eliminationBlockers[2].SetActive(true);
        }

        if (gameData.completedEliminationLevel4 == true)
        {
            eliminationBlockers[3].SetActive(false);
        }
        else
        {
            eliminationBlockers[3].SetActive(true);
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
