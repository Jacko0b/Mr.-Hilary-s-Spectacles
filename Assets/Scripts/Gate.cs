using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool opened=false;
    public Animator anim;
    public AudioSource aud;
    public void Open()
    {
        if (!opened)
        {
            opened = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("open", true);
            aud.Play();
        }
    }

    public void Close()
    {
        if (opened)
        {
            opened = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            anim.SetBool("open", false);
            aud.Play();
        }
    }
}
