using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScoreMulti : powerUpBaseClass
{

    public float bonusMultiplier;
    public float duration;
    public override IEnumerator applyPowerUp()
    {
        levelReference.setPowerupUi("Score Multiplier", duration); // updates level ui to display current power up 

        GetComponent<SpriteRenderer>().enabled = false;   // hide powerup while for its power up duration
        GetComponent<Collider2D>().enabled = false;    // hide powerup while for its power up duration

        levelReference.scoreMultiplier = bonusMultiplier;
        yield return new WaitForSeconds(duration);
        levelReference.scoreMultiplier = 1;

      
        Destroy(gameObject);
       
    }


}
