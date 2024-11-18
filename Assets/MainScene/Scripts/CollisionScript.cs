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
        //Flashlight flashlight = new Flashlight();
        //flashlight.ExtraCheck(LightOn);
        //*&& LightOn == true*

        //if (Input.GetKey(KeyCode.F))
        //{
        //    Debug.Log("CheckStarterLight");
        //    light1 = true;
        //}
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SecondaryStarterLight");
            light1 = false;
            light2 = true;
        }
        //if (other.gameObject.tag == "Enemy" && light1 == true)
        //{
        //    Destroy(other.gameObject);
        //    light1 = false;
        //    light2 = false;
        //}
        if (other.gameObject.tag == "Enemy" && light2 == true)
        {
            Destroy(other.gameObject);
            light1 = false;
            light2 = false;
        }
    }
}
