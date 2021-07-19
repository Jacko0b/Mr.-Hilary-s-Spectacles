using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public Animator anim;
    public AudioSource breaking;
    public AudioSource build;
    public bool breakable = true;
    public bool platformDestroyed = false;
    public float timeToDestroy = 2;
    public float timeToRepair = 5;
    private BoxCollider2D boxCollider;
    void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (breakable == true && platformDestroyed == false)
        {
            StartCoroutine(DestroyPlatform(timeToDestroy));
            
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (platformDestroyed)
        {
            StartCoroutine(RepairPlatform(timeToRepair));
        }
    }

    private IEnumerator DestroyPlatform(float time)
    {
        platformDestroyed = true;

        yield return new WaitForSecondsRealtime(time);

        boxCollider.enabled = false;
        anim.SetBool("brokenPlatform", true);
        breaking.Play();
    }

    private IEnumerator RepairPlatform(float time)
    {
        platformDestroyed = false;

        yield return new WaitForSecondsRealtime(time);
        

        boxCollider.enabled = true;
        anim.SetBool("brokenPlatform", false);
        build.Play();

    }
}
