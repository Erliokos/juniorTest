using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    private bool _fire = true;
    public bool rotate; // РАЗРЕШЕНИЕ НА ПОВОРОТ
    public float rotateSpeed;
    GameObject enemytarget; // ОБЪЕКТ ДЛЯ ПРИЦЕЛИВАНИЯ

    private void Start()
    {
        enemytarget = GameObject.Find("PlayerSpaceship");// ОБЪЕКТ ДЛЯ ПРИЦЕЛИВАНИЯ
    }

    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
        if (rotate) // РАЗРЕШЕНИЕ НА ПОВОРОТ
            movementSystem.RoteteToTarget(enemytarget, rotateSpeed); // ПОВОРОТ НА ЦЕЛЬ
    }
    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
