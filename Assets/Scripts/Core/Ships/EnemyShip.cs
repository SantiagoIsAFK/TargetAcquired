using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IA_MovType
{
    horizontal = 0,
    vertical = 5,
    random = 10,
    smartShort = 15,
    smartLarge = 20
}

public class EnemyShip : Ship
{
    public float TimeToShoot;
    public float CurrentShootTime;


    public IA_MovType movType;
    public float MovTime;
    public float CurrentMovTime;


    private void Update()
    {
        if (isAlive)
        {
            if (PlayerShip.Instance != null)
            {
                if (CurrentShootTime < TimeToShoot)
                {
                    CurrentShootTime += Time.deltaTime;
                }
                else
                {
                    Shoot();
                    CurrentShootTime = 0;

                }

                if (CurrentMovTime < MovTime)
                {
                    CurrentMovTime += Time.deltaTime;
                }
                else
                {

                    Mov();

                    CurrentMovTime = 0;
                }
            }
        }
    }

    [ContextMenu("Shoot")]
    public override void Shoot()
    {
        LaunchBullet();
    }


    private void Mov()
    {


        switch (movType)
        {
            case IA_MovType.horizontal:


                if (MovHorizontal())
                {
                }
                else if (MovVertical())
                {
                }
                else
                {
                    PlayerShip.Instance.Kill();
                }

                break;
            case IA_MovType.vertical:

                if (MovVertical())
                {
                }
                else if (MovHorizontal())
                {
                }
                else
                {
                    PlayerShip.Instance.Kill();
                }
                break;
            case IA_MovType.random:

                if (Random.Range(0, 2) == 0)
                {
                    if (MovHorizontal())
                    {
                    }
                    else if (MovVertical())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                else
                {
                    if (MovVertical())
                    {
                    }
                    else if (MovHorizontal())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                break;
            case IA_MovType.smartShort:
                if (Mathf.Abs(PlayerShip.Instance.tf.position.x - tf.position.x) < Mathf.Abs(PlayerShip.Instance.tf.position.z - tf.position.z))
                {
                    if (MovHorizontal())
                    {
                    }
                    else if (MovVertical())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                else if (Mathf.Abs(PlayerShip.Instance.tf.position.x - tf.position.x) > Mathf.Abs(PlayerShip.Instance.tf.position.z - tf.position.z))
                {
                    if (MovVertical())
                    {
                    }
                    else if (MovHorizontal())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        if (MovHorizontal())
                        {
                        }
                        else if (MovVertical())
                        {
                        }
                        else
                        {
                            PlayerShip.Instance.Kill();
                        }
                    }
                    else
                    {
                        if (MovVertical())
                        {
                        }
                        else if (MovHorizontal())
                        {
                        }
                        else
                        {
                            PlayerShip.Instance.Kill();
                        }
                    }
                }
                break;
            case IA_MovType.smartLarge:
                if (Mathf.Abs(PlayerShip.Instance.tf.position.x - tf.position.x) > Mathf.Abs(PlayerShip.Instance.tf.position.z - tf.position.z))
                {
                    if (MovHorizontal())
                    {
                    }
                    else if (MovVertical())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                else if (Mathf.Abs(PlayerShip.Instance.tf.position.x - tf.position.x) < Mathf.Abs(PlayerShip.Instance.tf.position.z - tf.position.z))
                {
                    if (MovVertical())
                    {
                    }
                    else if (MovHorizontal())
                    {
                    }
                    else
                    {
                        PlayerShip.Instance.Kill();
                    }
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        if (MovHorizontal())
                        {
                        }
                        else if (MovVertical())
                        {
                        }
                        else
                        {
                            PlayerShip.Instance.Kill();
                        }
                    }
                    else
                    {
                        if (MovVertical())
                        {
                        }
                        else if (MovHorizontal())
                        {
                        }
                        else
                        {
                            PlayerShip.Instance.Kill();
                        }
                    }
                }
                break;
            default:
                break;
        }

    }


    private bool MovHorizontal()
    {
        if (PlayerShip.Instance.tf.position.x < tf.position.x)
        {
            tf.Translate(Vector3.left, Space.World);
            tf.eulerAngles = new Vector3(0,270,0);
            return true;
        }
        else if (PlayerShip.Instance.tf.position.x > tf.position.x)
        {
            tf.Translate(Vector3.right, Space.World);
            tf.eulerAngles = new Vector3(0, 90, 0);

            return true;
        }
        else
        {
            return false;
        }
    }

    private bool MovVertical()
    {
        if (PlayerShip.Instance.tf.position.z < tf.position.z)
        {
            tf.Translate(Vector3.back, Space.World);
            tf.eulerAngles = new Vector3(0, 180, 0);
            return true;
        }
        else if (PlayerShip.Instance.tf.position.z > tf.position.z)
        {
            tf.Translate(Vector3.forward, Space.World);
            tf.eulerAngles = new Vector3(0, 0, 0);
            return true;
        }


        return false;
    }
}
