using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    //public bool LightOn = false;
    public int EnemyHealth = 100;
    public int TakeDamage = 10;
    void OnTriggerStay(UnityEngine.Collider other)
    {
        //Flashlight flashlight = new Flashlight();
        //flashlight.ExtraCheck(LightOn);

        if (other.gameObject.tag == "Enemy" /*&& LightOn == true*/)
        {
            Destroy(other.gameObject);
        }
    }
}
