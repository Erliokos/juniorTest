using Gameplay.ShipSystems;
using UnityEngine;


namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {


        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            
            
                movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);

           if(transform.position.x<movementSystem.limitLeft) // ограничение движения player left
            {
                transform.position = new Vector3(movementSystem.limitLeft, transform.position.y, transform.position.z);
            }
            if (transform.position.x > movementSystem.limitRight) // ограничение движения player right
            {
                transform.position = new Vector3(movementSystem.limitRight, transform.position.y, transform.position.z);
            }

        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFirePlayer(0);
                fireSystem.TriggerFirePlayer(1);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                fireSystem.TriggerFirePlayer(2);
               
            }
        }
    }
}
