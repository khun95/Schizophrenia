using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOutCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isOut = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            isOut = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            isOut = false;
        }
    }
}
