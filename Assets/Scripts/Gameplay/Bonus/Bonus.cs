using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;
namespace Gameplay.Bonus
{
    public class Bonus : MonoBehaviour
    {

        [SerializeField]
        private float _speed;      
        

        private void Update()
        {
            MoveBonus(_speed);
        }


        private void MoveBonus(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }



    }
}

