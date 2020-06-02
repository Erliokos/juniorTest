using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Bonus;

public class BonusWeaponSpeed : Bonus
{
    public float awardedMultiplySpeed;
    public float livetime;

    private void OnCollisionEnter2D(Collision2D other)
    {

        var awarded = other.gameObject.GetComponent<IBonus>();

        if (awarded != null
            && other.gameObject.tag == "Player")
        {

            awarded.TakeWeaponSpeed(awardedMultiplySpeed,livetime);
            Destroy(gameObject);

        }
    }


}
