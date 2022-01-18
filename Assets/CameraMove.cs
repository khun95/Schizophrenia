using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public Transform target;

	public float dist = 7f;
	public float height = 5f;

	// Use this for initialization
	private Transform tr;
	void Start()
	{

		tr = GetComponent<Transform>();

	}

	// Update is called once per frame

	void Update()
	{
		tr.position = target.position - (1 * Vector3.forward * dist) + (Vector3.up * height);
		tr.LookAt(target);

	}

}
