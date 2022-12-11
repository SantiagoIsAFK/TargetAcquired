using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerShip"))
        {
            //conexion al core
            NaveTopDownCore.Instance.CollectPoints(5);

            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            NaveTopDownCore.Instance.CollectPoints(5);

            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }


    
}
