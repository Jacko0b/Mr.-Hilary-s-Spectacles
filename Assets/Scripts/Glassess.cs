using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Glassess : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject UiWygrana;
    public AudioSource pickup;
    public AudioSource victory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //button to menu

            pickup.Play();
            victory.Play();
            Time.timeScale = 0;
            FindObjectOfType<Camera>().GetComponent<AudioSource>().volume = 0;
            UiWygrana.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            player.GetComponent<Animator>().Play("wygrana");
        }
    }
    public void buttonToMenu()
    {
        //to menu
        Debug.Log("tomenu");
        SceneManager.LoadScene(0);
    }

}
