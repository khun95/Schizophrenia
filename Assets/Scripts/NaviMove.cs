using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviMove : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GameObject target;
    private bool isFinish = false;

    private void Awake()
    {
        target = GameObject.Find("PFB_Building_Base");
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(StartNavi());
    }

    private void Update()
    {
        gameObject.transform.LookAt(target.transform.position);
        if (isFinish)
        {
            StartCoroutine(StartNavi());
            isFinish = false;
        }
    }

    IEnumerator StartNavi()
    {
        Debug.Log("1");
        GameObject target1 = GameObject.Find("Target 1");
        _agent.SetDestination(target1.transform.position);
        yield return new WaitForSeconds(5f);
        Debug.Log("2");
        GameObject target2 = GameObject.Find("Target 2");
        _agent.SetDestination(target2.transform.position);
        yield return new WaitForSeconds(5f);
        Debug.Log("3");
        GameObject target3 = GameObject.Find("Target 3");
        _agent.SetDestination(target3.transform.position);
        yield return new WaitForSeconds(5f);
        Debug.Log("4");
        GameObject target4 = GameObject.Find("Target 4");
        _agent.SetDestination(target4.transform.position);
        yield return new WaitForSeconds(5f);
        Debug.Log("5");
        GameObject target5 = GameObject.Find("Target 5");
        _agent.SetDestination(target5.transform.position);
        yield return new WaitForSeconds(5f);
        Debug.Log("6");
        GameObject target6 = GameObject.Find("Target 6");
        _agent.SetDestination(target6.transform.position);
        yield return new WaitForSeconds(5f);
        isFinish = true;
    }
}
