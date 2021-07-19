using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOpeningGate : MonoBehaviour
{
    public Gate gate;
    public Spider spider;
    public AudioSource aud;
    public Animator anim;
    void FixedUpdate()
    {
        checkSpider();
    }

    public void checkSpider()
    {
        if (gate.opened && !spider.isCrawling)
        {
            spider.crawl(gameObject.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spider"))
        {
            aud.Play();
            anim.SetBool("on", false);
            gate.Close();
        }
        else 
        {

            aud.Play();
            anim.SetBool("on", true);
            gate.Open();
        } 
    }

}
