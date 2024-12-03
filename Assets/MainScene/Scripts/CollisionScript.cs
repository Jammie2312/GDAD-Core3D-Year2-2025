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
    public bool light1 = false;    
    public bool light2 = false;

    public AudioSource growlSound;

    public SkinnedMeshRenderer skinnedMesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    public int mainLight;

    private Material[] skinnedMaterials;

    void Start()
    {
        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
    }



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
            //Destroy(other.gameObject);
            light1 = false;
            light2 = false;
        }
    }

    IEnumerator DissolveCo()
    {
        if (skinnedMaterials.Length > 0)
        {
            growlSound.Play();
            float counter = 0;
            while (skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
