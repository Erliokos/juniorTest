using System;
using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Bonus;
using Random = UnityEngine.Random;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IBonus
    {
        

        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        private GameObject BonusPanel; // объект ui
        private GameObject ArmorPanel; // объект ui
        private GameObject RestartPanel;//объект ui
        public GameObject[] TypeBonus;


        public float armor = 1;// броня коробля
        public float damageOneShot = 0.1f; // УРОН ЗА ОДИН ВЫСТРЕЛ
        public int bonus;// бонус при попадании



        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
        {
            BonusPanel = GameObject.Find("BonusPanel");//находим объект ui 
            if (_battleIdentity.ToString() != "Enemy")
            {
                RestartPanel = GameObject.Find("RestartPanel");//находим объект ui если это не враг
                ArmorPanel = GameObject.Find("ArmorPanel");//находим объект ui если это не враг
               
            }
                
            
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);

        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            if (armor < damageOneShot)
            {
                if (_battleIdentity.ToString() != "Enemy")
                {
                    RestartPanel.GetComponent<RestartPanel>().ShowRestartPanel(); // вызываем панель рестарта
                }
                else
                    CreateBonusAfterDeadEnemy(); // выкидываем бонус

                Destroy(gameObject);
            }
            else
            {
                armor-=damageOneShot;
                if (_battleIdentity.ToString() != "Enemy")
                    ArmorPanel.GetComponent<ArmorPanel>().ArmorDamage(damageOneShot,armor); // посылаем в ui минус к здоровью

            }
            SendToUI();
        }

        void SendToUI() //зачисляем бонус
        { 
            if(_battleIdentity.ToString() == "Enemy")// если враг то зачисляем бонус
            BonusPanel.GetComponent<BonusPanel>().PlusPoint(bonus); //зачисление бонуса
            
        }


       public void TakeArmor(float getarmor) // реализация с помощью интерфейса IBonus
        {
            armor += getarmor ; // востанавливаем здоровье физически
            if (armor > 1)
                armor = 1;
            ArmorPanel.GetComponent<ArmorPanel>().ArmorDamage(damageOneShot, armor+ damageOneShot); // востанавливаем здоровье визуально
        }

        public void TakeWeaponSpeed(float getspeed,float livetime) // реализация с помощью интерфейса IBonus
        {
            BonusEneble(getspeed);
            StartCoroutine(LiveBonus(livetime, getspeed));
            
        }


        private IEnumerator LiveBonus(float LiveTime,float getspeed) // считает время жизни
        {
            yield return new WaitForSeconds(LiveTime); 
            BonusDisable(getspeed);
        }

        void BonusEneble(float getspeed) // включает действие бонуса скорость стрельбы
        {
            foreach (Transform child in gameObject.transform)
            {
                foreach (Transform childTwo in child.transform)
                    childTwo.GetComponent<Weapon>()._cooldown /= getspeed;
            }
        }
        void BonusDisable(float getspeed) // выключает действие бонуса скорость стрельбы
        {
            foreach (Transform child in gameObject.transform)
            {
                foreach (Transform childTwo in child.transform)
                    childTwo.GetComponent<Weapon>()._cooldown *= getspeed;
            }
        }

        void CreateBonusAfterDeadEnemy()  // создает бонусы после смерти 
        {
            int ver = Random.Range(0, 4);
            if(ver<2)
            Instantiate(TypeBonus[ver], transform.position, TypeBonus[ver].transform.rotation);
        }




    }
}
