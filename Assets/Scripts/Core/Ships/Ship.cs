using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public abstract class Ship : MonoBehaviour
{

    public UnityEvent OnBorn, OnShoot, OnDead;
    public bool isAlive;



    public Transform tf;
    public Transform aim;

    public GameObject bulletPrefab;

    protected virtual void Awake()
    {
        tf = transform;

    }


    [ContextMenu("Born")]
    //[ContextMenuItem("Born", "Born")]
    public void Born()
    {
        OnBorn?.Invoke();

        Invoke("FinishBorn", 1);
    }

    public void FinishBorn()
    {
        isAlive = true;
    }


    public abstract void Shoot();


    protected void LaunchBullet()
    {
        Instantiate(bulletPrefab, aim.position, tf.rotation);
        OnShoot?.Invoke();
    }

    [ContextMenu("Kill")]
    public void Kill()
    {
        if (!killing)
        {
            NaveTopDownCore.Instance.CollectPoints(8);
            OnDead?.Invoke();


            Invoke("FinishDead", 2);
            killing = true;
            isAlive = false;
        }
    }

    private bool killing;
    protected virtual void FinishDead()
    {
        Destroy(gameObject);
    }

}
