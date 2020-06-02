using System.Collections;
using System.Collections.Generic;
using Gameplay.Helpers;
using UnityEngine;

public class BackGroundDestructor : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _representation;
    public GameObject startPoint;


    void Update()
    {
        CheckBorders();
    }

    private void CheckBorders()
    {
        if (!GameAreaHelper.IsInGameplayArea(transform, _representation.bounds,Camera.main))
        {
            transform.position = startPoint.transform.position;
        }
    }
}
