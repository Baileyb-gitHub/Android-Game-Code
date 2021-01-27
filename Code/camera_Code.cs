using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Code : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        uppdateAudioListener();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) 
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
       
    }


    public void uppdateAudioListener()   // sets volume of listner to current value stored in game data as player choice
    {
        float newVol = AudioListener.volume;
        newVol = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>().gameVolume;
        AudioListener.volume = newVol;
    }


}
