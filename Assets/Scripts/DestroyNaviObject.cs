using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNaviObject : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject scarecrow;
	public GameObject crow;
	private GameObject colliderArea;
	public bool isOpen = false;
    void Start()
    {
		crow = Instantiate(scarecrow);
		colliderArea = GameObject.Find("ColliderArea");
	}

    // Update is called once per frame
    void Update()
    {
		isOpen = colliderArea.GetComponent<WalkOutCollider>().isOut;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log(isOpen);
			if (isOpen)     //player has collided with trigger
			{
				for (int i = 0; i <crow.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
					crow.GetComponentsInChildren<SkinnedMeshRenderer>()[i].enabled = false;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")      //player has exited trigger
		{
			for (int i = 0; i < crow.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
				crow.GetComponentsInChildren<SkinnedMeshRenderer>()[i].enabled = true;
		}
	}
}
