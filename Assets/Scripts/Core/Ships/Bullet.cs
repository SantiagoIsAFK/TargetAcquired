using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public bool IsPlayerBullet;

    private void Awake()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*force, ForceMode.Impulse);

        Invoke("AutoDestroy", 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((collision.collider.CompareTag("EnemyShip") || collision.collider.CompareTag("PlayerShip")) && !IsPlayerBullet) 
            ||
            (collision.collider.CompareTag("EnemyShip") && IsPlayerBullet)) 
        {
            collision.collider.GetComponent<Ship>().Kill();

            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }


    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
