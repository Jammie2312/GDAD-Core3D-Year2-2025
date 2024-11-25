using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool flashlight = false;
    public GameObject lightSource1;
    public GameObject lightSource2;
    public AudioSource clickSound;
    public AudioSource SizzSound;
    public bool failSafe = false;

    [Range(0f, 5f)]
    public float failsafeDuration = 1f; // Cooldown in seconds between shots
    private float lastFlashTime = -100f; // Initialize to a low value

    public void Update()
    {
        //flashlight
        if (Input.GetButtonDown("LightOnOff"))
        {
            if (flashlight == false)
            {
                lightSource1.SetActive(true);
                clickSound.Play();
                flashlight = true;
            }
            else 
            {
                lightSource1.SetActive(false);
                clickSound.Play();
                flashlight = false;
            }
        }


            // Check for spacebar input and shoot if cooldown has elapsed
        if (Input.GetButton("Intense") && Time.time > lastFlashTime + failsafeDuration)
        {

            if (failSafe == false && flashlight == true)
            {
                failSafe = true;
                flashlight = false;

                SizzSound.Play();
                SizzSound.volume = 1;

                Debug.Log("failsafe");
                lightSource2.SetActive(true);
                lightSource1.SetActive(false);
                // Update the last flash time to enforce cooldown
                lastFlashTime = Time.time;

                StartCoroutine(FailSafe());
            }
        }

    }

    public IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(failsafeDuration);

        //todo add sound here for failsafe off
        SizzSound.volume = 0;
        clickSound.Play();

        lightSource2.SetActive(false);
        lightSource1.SetActive(false);
        flashlight = false;
        failSafe = false;
    }
}
