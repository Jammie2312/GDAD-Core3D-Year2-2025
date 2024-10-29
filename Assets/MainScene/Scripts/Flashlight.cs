using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    public AudioSource clickSound;
    public AudioSource SizzSound;
    public bool failSafe = false;

    private void Start()
    {
        Invoke("SpawnDelay", 1);
    }

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
        if (Input.GetButtonDown("LightOnOff"))
        {
            if (isOn == true && failSafe == false)
            { 
                failSafe = true;
                SizzSound.Play();
                isOn = true;
                StartCoroutine(FailSafe());
            }
        }
        if (Input.GetButtonDown("Intense"))
        {
            
        }
    }

    void start()
    {
        Invoke("SpawnDelay", 2);
    }
    private void SpawnDelay()
    {
        SizzSound.Play();
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.1f);
        failSafe = false;
    }
}
