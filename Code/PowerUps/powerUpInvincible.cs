using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpInvincible : powerUpBaseClass
{

    public float duration;

    public override IEnumerator applyPowerUp()
    {
        levelReference.setPowerupUi("Invincible", duration); // updates level ui to display current power up 

        GetComponent<SpriteRenderer>().enabled = false;  // hide powerup while for its power up duration
        GetComponent<Collider2D>().enabled = false;  // hide powerup while for its power up duration

        playerReference.invincible = true;
        yield return new WaitForSeconds(duration);
        playerReference.invincible = false;

      
        Destroy(gameObject);

    }

}
