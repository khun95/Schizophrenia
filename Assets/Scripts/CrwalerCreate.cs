using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrwalerCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crawler;
    private bool isCol = false;
    private int colCount = 0;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            isCol = true;
            colCount++;
            Debug.Log("충돌");
            if (isCol)
            {
                StartCoroutine(crawlerInstantiate());
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            isCol = false;
            Debug.Log("충돌");
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator crawlerInstantiate()
    {
        yield return new WaitForSeconds(0.1f);
        if (colCount == 1)
        {

            Instantiate(crawler);
            isCol = false;

        }

    }
}
