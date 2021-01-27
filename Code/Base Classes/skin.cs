using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skin : MonoBehaviour
{
    public uiSkinHandler skinHandler;
    public Game_Data gameData;
    public GameObject selectedText;
    public GameObject skinLockedUI;
    public TextMeshProUGUI skinLockedText;
    [Space]
    public int skinNum;
    [Space]
    public SpriteRenderer skinImage;
    public Material unlockedMaterial;
    public Material lockedMaterial;
    [Space]
    public TextMeshProUGUI skinName;
    public string unlockedName;
    public string lockedName;
    [Space]
    public string unlockedMotto;
    public string lockedMotto;
    [Space]
    public bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        refreshUI();
    }

    public  void refreshUI()   // checks if skin is unlocked and updates ui
    {
        unlocked = false;

        switch (skinNum) 
        {
            case 1:
                unlocked = true;
                break;

            case 2:
                if (gameData.skin2Unlocked == true)
                { unlocked = true;}
                break;

            case 3:
                if (gameData.skin3Unlocked == true)
                { unlocked = true; }
                break;

            case 4:
                if (gameData.skin4Unlocked == true)
                { unlocked = true; }
                break;

            case 5:
                if (gameData.skin5Unlocked == true)
                { unlocked = true; }
                break;

            case 6:
                if (gameData.skin6Unlocked == true)
                { unlocked = true; }
                break;

            case 7:
                if (gameData.skin7Unlocked == true)
                { unlocked = true; }
                break;

            case 8:
                if (gameData.skin8Unlocked == true) 
                { unlocked = true; }
                break;

            case 9:
                if (gameData.skin9Unlocked == true) 
                { unlocked = true; }
                break;

            case 10:
                if (gameData.skin10Unlocked == true)
                { unlocked = true; }
                break;

            default:
                unlocked = false;
                break;

        }

        if(unlocked == true) 
        {
            skinName.text = unlockedName;
            skinImage.material = unlockedMaterial;

            if(gameData.skinOfChoice == skinNum) 
            {
                selectedText.SetActive(true);
            }
           else
           {
                selectedText.SetActive(false);
           }
        }
        else 
        {
            skinName.text = lockedName;
            skinImage.material = lockedMaterial;
            selectedText.SetActive(false);
        }

    }

    public  void skinPressed()   // checks if skin is unlocked and updates ui
    {
        Debug.Log("skin - " + skinNum+ "  button pressed");
        if(unlocked == true) 
        {
            skinHandler.unSelectSkinsUI();
            gameData.skinOfChoice = skinNum;
            selectedText.SetActive(true);
            
        }
        else 
        {
            skinLockedUI.SetActive(true);
            skinLockedText.text = lockedMotto;
         // load ui with motton explanation eg how to unlock
        }
    }

    public virtual void removeSelectedText()   // checks if skin is unlocked and updates ui
    {
        selectedText.SetActive(false);
        Debug.Log("removed text of skin number " + skinNum);
    }

}
