using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderMove : MonoBehaviour
{
    public GameObject slender;
    public Animator animator;
    public GameObject target;
    public bool isScream = true;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = slender.GetComponent<Animator>();
        
        StartCoroutine(SlenderRun());
    }
    IEnumerator SlenderRun()
    {
        yield return new WaitForSeconds(0.1f);
        slender.GetComponent<Rigidbody>().velocity = new Vector3(-3f, 0, 0);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("Sc", isScream);
        slender.GetComponent<Rigidbody>().velocity = Vector3.zero;
        slender.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(3.5f);
        Destroy(slender.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
