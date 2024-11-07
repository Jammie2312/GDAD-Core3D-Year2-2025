using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public int EnemyHealth = 100;
    public int TakeDamage = 10;
    void OnTriggerStay(UnityEngine.Collider other)
    {

        if (other.gameObject.tag == "Enemy" && EnemyHealth < 0)
        {
            Destroy(other.gameObject);
        }
    }
}
