using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem.Android;
using UnityEngine.Rendering.Universal;

public class CollisionScript : MonoBehaviour
{
    //public bool LightOn = false;
    public int EnemyHealth = 100;
    public int TakeDamage = 10;
    public bool light1 = false;    
    public bool light2 = false;

    void OnTriggerStay(UnityEngine.Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SecondaryStarterLight");
            light1 = false;
            light2 = true;
        }

        if (other.gameObject.tag == "Enemy" && light2 == true)
        {
            Destroy(other.gameObject);
            light1 = false;
            light2 = false;
        }
    }
}
