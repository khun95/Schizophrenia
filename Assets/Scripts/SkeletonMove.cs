using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonMove : MonoBehaviour
{
    private GameObject target;
    private Animator skeletonAnimator;
    private UnityEngine.AI.NavMeshAgent navAgent;
    private bool isRun = false;
    public Light directionalLight;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        skeletonAnimator = GetComponent<Animator>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        StartCoroutine(SkeletonMoveCoroutin());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(target.transform.position);
        if (isRun == true)
        {
            navAgent.SetDestination(target.transform.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    IEnumerator SkeletonMoveCoroutin()
    {
        directionalLight.GetComponent<Light>().color = Color.white;
        yield return new WaitForSeconds(6f);
        skeletonAnimator.SetBool("isCome", true);
        isRun = true;
    }
}
