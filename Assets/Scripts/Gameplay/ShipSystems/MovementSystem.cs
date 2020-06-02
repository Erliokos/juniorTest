using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed;

        [SerializeField]
        private float _longitudinalMovementSpeed;

        public float limitRight; //ограничители движения player
        public float limitLeft; //ограничители движения player


        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }


        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }

        public void RoteteToTarget(GameObject EnemyTarget, float speed) // метод для поворота вражеского коробля на цель
        {

            if (EnemyTarget != null)
            {
                Vector3 direction = (EnemyTarget.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion rotate = Quaternion.AngleAxis(Mathf.Clamp(-angle,-150,-210), Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotate, speed * Time.deltaTime);         
            }
        }
    }
}
