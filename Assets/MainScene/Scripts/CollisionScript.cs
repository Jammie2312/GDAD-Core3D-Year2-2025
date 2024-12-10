using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class CollisionScript : MonoBehaviour
{
    //public GameObject light1;    
    //public GameObject light2;

    private Flashlight flashlight;

    public AudioSource growlSound;


    public SkinnedMeshRenderer skinnedMesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    private Material[] skinnedMaterials;

    public Animator _animator;


    public Transform playerTransform;
    
    NavMeshAgent agent;

    public bool NavCheck = true;

    void Start()
    {
        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;

        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        flashlight = player.GetComponent<Flashlight>(); 
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //if (Input.GetButton("Intense"))
        //{
        //    StartCoroutine(DissolveCo());
        //}
        if (NavCheck == true)
        {
            agent.destination = playerTransform.position;
        }
    }



    void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("Colliding Check");

        if (other.gameObject.tag == "Collide" && flashlight.failSafe == true && NavCheck == true)
        {
            Debug.Log("2nd light check");
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo()
    {
        if (skinnedMaterials.Length > 0)
        {
            growlSound.Play();
            _animator.Play("Z_FallingForward");
            float counter = 0;
            NavCheck = false;

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

        //yield return new WaitForSeconds(2f);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
