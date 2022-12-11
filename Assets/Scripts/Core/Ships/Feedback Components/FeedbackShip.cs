using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeedbackShip : MonoBehaviour
{
    protected Ship ship;

    protected virtual void Awake()
    {
        ship = GetComponent<Ship>();
    }
}
