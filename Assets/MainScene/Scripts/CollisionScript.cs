using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CollisionScript : MonoBehaviour
{
    private Flashlight flashlight;

    NavMeshAgent agent;

    //Enemy death properties
    public AudioSource growlSound;
    public SkinnedMeshRenderer skinnedMesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    private Material[] skinnedMaterials;
    public Animator _animator;

    //Players position
    public Transform playerTransform;
    
    //Checks
    public bool NavCheck = true;
    public bool Alive = true;

    void Start()
    {
        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;

        //getting the components for enemy
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        flashlight = player.GetComponent<Flashlight>(); 
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Enemy follows players position
        if (NavCheck == true)
        {
            agent.destination = playerTransform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collide" && flashlight.failSafe == true && NavCheck == true && Alive == true)
        {
            Debug.Log("2nd light check");
            StartCoroutine(DissolveCo());
            Alive = false;
        }
    }

    IEnumerator DissolveCo()
    { 
        if (skinnedMaterials.Length > 0)
        {
            NavCheck = false;
            growlSound.Play();
            _animator.Play("Z_FallingForward");
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

        //Delay to wait unitl enemy is dissolved
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
