using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public AudioSource aud;
    private Vector3 startingPosition;
    private Vector3 destination;
    public bool isCrawling = false;
    public bool movingForward = false;
    public bool movingBack = false;
    public float speed= 2f;
    public float timeToGo = 2f;
    private void Awake()
    {
        startingPosition = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        spiderMovingForward();
        spiderMovingBackward();

    }
    private void spiderMovingForward()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            aud.mute = false;
        }
        if (transform.position == destination)
        {
            aud.mute = true;
            movingForward = false;
        }
    }
    private void spiderMovingBackward()
    {
        if (movingBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, Time.deltaTime * speed);
            aud.mute = false;
        }
        if (transform.position == startingPosition)
        {
            aud.mute = true;
            movingBack = false;

        }
    }

   

    public void crawl(Vector3 dest)
    {
        destination = dest;
        StartCoroutine(SpiderCrawl(destination));
    }

    IEnumerator SpiderCrawl(Vector3 destination)
    {

        isCrawling = true;
        yield return new WaitForSecondsRealtime(timeToGo);
        movingForward = true;

        yield return new WaitForSecondsRealtime(1);
        movingBack = true;

        isCrawling = false;
    }
}
