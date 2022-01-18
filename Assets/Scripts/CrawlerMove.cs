using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crawler;
    public Animator animator;
    public GameObject target;
    public bool isJump = true;
    private bool isCol = false;
    void Start()
    {
        animator = crawler.GetComponent<Animator>();
        StartCoroutine(CrawlerRun());

        target = GameObject.Find("Player");
    }
    void Update()
    {
        //gameObject.transform.LookAt(target.transform);
        if (isCol)
        {
            Destroy(crawler.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            isCol = true;
        }
    }
    IEnumerator CrawlerRun()
    {
        
        yield return new WaitForSeconds(0.1f);
        crawler.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1.5f);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isJump", isJump);
        CrawlerStop();
        yield return new WaitForSeconds(0.5f);
        crawler.GetComponent<Rigidbody>().velocity = new Vector3(0, 1f, -2.5f);
        yield return new WaitForSeconds(1f);
        CrawlerStop();
        

    }

    private void CrawlerStop()
    {
        crawler.GetComponent<Rigidbody>().velocity = Vector3.zero;
        crawler.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    // Update is called once per frame
}
