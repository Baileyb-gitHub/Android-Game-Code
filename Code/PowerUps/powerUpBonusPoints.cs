using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpBonusPoints : powerUpBaseClass
{
    public float bonusPoints;

    public override IEnumerator applyPowerUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        levelReference.score += bonusPoints;
        Destroy(gameObject);
        return null;
    }
}
