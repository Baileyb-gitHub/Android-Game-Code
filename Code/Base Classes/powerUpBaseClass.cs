using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class powerUpBaseClass : MonoBehaviour  // base class for powerups handling getting of player and level data references  as well as trigger detection
{
    [Header("References")]
    public Level_Data levelReference;
    public player_Controller playerReference;
    public GameObject pickupParticles;
    public GameObject pickUpAudio;


    private void Start()
    {
        levelReference = GameObject.FindWithTag("Level Data").GetComponent<Level_Data>();
        playerReference = GameObject.FindWithTag("Player").GetComponent<player_Controller>();
    }

    public virtual IEnumerator applyPowerUp()
    {

        Debug.Log("Defualt power up function, need to overide ");
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player") 
        {
            levelReference.powerUpCount -= 1;  // removes poweup for active powerUp count
            Instantiate(pickupParticles, transform.position, Quaternion.identity);
            Instantiate(pickUpAudio, transform.position, Quaternion.identity);
            StartCoroutine( applyPowerUp()     );
        }
       
       
    }

}
