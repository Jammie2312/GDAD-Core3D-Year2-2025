using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareContoller : MonoBehaviour
{
    [SerializeField] public Image jumpscareImage;
    [SerializeField] public Sprite jumpscareImage2;
    [SerializeField] public GameObject jumpscareImage3;
    public AudioClip jumpscareClip1;
    public AudioSource jumpsource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //jumpscareImage.enabled = true;
            jumpscareImage3.SetActive(true);
            jumpscareImage.sprite = jumpscareImage2;    
            jumpsource.PlayOneShot(jumpscareClip1);
            StartCoroutine(CloseJumpscare());
            //SceneManager.LoadScene("UI");
        }
    }

    private IEnumerator CloseJumpscare()
    {
        yield return new WaitForSeconds(2);
        //jumpscareImage.enabled = false;
        SceneManager.LoadScene("UI");
    }
}
