using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource1;
    public GameObject lightSource2;
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
                lightSource1.SetActive(true);
                clickSound.Play();
                isOn = true;
                StartCoroutine(FailSafe());
                if (Input.GetButtonDown("Intense"))
                {
                    Debug.Log("Light");
                    lightSource2.SetActive(true);
                    SizzSound.Play();
                }
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource1.SetActive(false);
                clickSound.Play();
                isOn = false;
                StartCoroutine(FailSafe());
            }

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
