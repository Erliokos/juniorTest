using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Bonus;

public class BonusArmor : Bonus
{
    public float awardedArmor;

    private void OnCollisionEnter2D(Collision2D other)
    {

        var awarded = other.gameObject.GetComponent<IBonus>();

        if (awarded != null
            && other.gameObject.tag == "Player")
        {

            awarded.TakeArmor(awardedArmor);
            Destroy(gameObject);

        }
    }


}
