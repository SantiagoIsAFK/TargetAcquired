using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : Ship
{
    public static PlayerShip Instance;

    public float ShootCooldown;
    public float CurrentCooldown;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void Update()
    {
        if (CurrentCooldown<ShootCooldown)
        {
            CurrentCooldown += Time.deltaTime;
        }
    }

    [ContextMenu("Shoot")]
    public override void Shoot()
    {
        if (CurrentCooldown>=ShootCooldown && isAlive)
        {
            LaunchBullet();
            CurrentCooldown = 0;
        }
    }


    public void MovUp(InputAction.CallbackContext ctx)
    {
        if (isAlive && ctx.performed)
        {
            tf.Translate(Vector3.forward, Space.World);
            tf.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void MovDown(InputAction.CallbackContext ctx)
    {
        if (isAlive)
        {
            tf.Translate(Vector3.back, Space.World);
            tf.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void MovLeft(InputAction.CallbackContext ctx)
    {
        if (isAlive)
        {
            tf.Translate(Vector3.left, Space.World);
            tf.eulerAngles = new Vector3(0, 270, 0);
        }
    }
    public void MovRight(InputAction.CallbackContext ctx)
    {
        if (isAlive)
        {
            tf.Translate(Vector3.right, Space.World);
            tf.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    protected override void FinishDead()
    {
        Destroy(gameObject);
        Instance = null;
    }

}
