using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareContoller : MonoBehaviour
{
    [SerializeField] public Image jumpscareImage;
    [SerializeField] public Sprite jumpscareSprite;
    [SerializeField] public GameObject jumpscareStore;
    public AudioClip jumpscareClip1;
    public AudioSource jumpsource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            jumpscareStore.SetActive(true);
            jumpscareImage.sprite = jumpscareSprite;
            jumpsource.PlayOneShot(jumpscareClip1);
            StartCoroutine(CloseJumpscare());
        }
    }

    private IEnumerator CloseJumpscare()
    {
        yield return new WaitForSeconds(1.5f);
        //jumpscareImage.enabled = false;
        SceneManager.LoadScene("UI");
    }
}
