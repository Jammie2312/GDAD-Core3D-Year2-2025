using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    public AudioSource clickSound;
    public AudioSource IntenseSound;
    public bool failSafe = false;

    void Update()
    {
        if (Input.GetButtonDown("LightOnOff"))
        {
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
                clickSound.Play();
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                clickSound.Play();
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
        if (Input.GetButtonDown("Intense"))
        {
            IntenseSound.Play();
            if (lightSource == true)
            {
                
            }
        }
    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.1f);
        failSafe = false;
    }
}
