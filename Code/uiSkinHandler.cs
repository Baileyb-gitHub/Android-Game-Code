using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiSkinHandler : MonoBehaviour
{

    public List<skin> skinsList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refreshSkinsUI() 
    {/*
        Debug.Log("refresh skin func");
        
        for (int i = 0; i < 10; i++) 
        {
            Debug.Log("refresh skin loop");
            skinList[i].refreshUI();
        }
            
        Debug.Log("refresh skin func DONE"  );
        */
    }

    public void unSelectSkinsUI()
    { 
       
        foreach (skin mySkin in skinsList)
        {
            Debug.Log("remove skin loop");
            mySkin.removeSelectedText();
        }

        
    }

}
