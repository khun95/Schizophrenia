using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
	// Start is called before the first frame update
	private float reachRange = 2f;
	private GameObject player;
	private Camera fpsCam;
	private bool playerEntered;
	private int rayLayerMask;
	public GameObject lights;
	private bool isLight = true;
	private bool showInteractMsg = false;
	private GUIStyle guiStyle;
	private string msg = "Press Space to turn on";
	bool isTurn = true;
	private GameObject imageObj;
	private int num;
	MoveableObject moveableObject;
	private AudioSource audioSource;
	public int isSlender = 0;
	
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		fpsCam = Camera.main;
		if (fpsCam == null) //a reference to Camera is required for rayasts
		{
			Debug.LogError("A camera tagged 'MainCamera' is missing.");
		}
		audioSource = GameObject.Find("SwitchSoundManager").GetComponent<AudioSource>();
		//create AnimatorOverrideController to re-use animationController for sliding draws.

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("SwitchRaycast");
		rayLayerMask = 1 << iRayLM.value;
		setupGui();
		imageObj = GameObject.FindGameObjectWithTag("TargetImage");
		num = GetComponent<MoveableObject>().objectNumber;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)     //player has collided with trigger
		{
			playerEntered = true;
			Debug.Log("Enter");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)     //player has exited trigger
		{
			playerEntered = false;
			
			//hide interact message as player may not have been looking at object when they left
			Debug.Log("Exit");
			showInteractMsg = false;
		}
	}
	// Update is called once per frame
	void Update()
    {
		if (playerEntered)
		{
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			Debug.DrawRay(rayOrigin, fpsCam.transform.forward * reachRange, Color.red);
			if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
			{

				showInteractMsg = true;
				imageObj.GetComponent<Image>().color = Color.green;
				msg = getGuiMsg(isTurn);
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Debug.Log("ºÒ²ô±â");
					audioSource.Play();
					lights.gameObject.SetActive(!isLight);
					if(num == 1)
                    {
						isSlender++;
						GetComponent<SlenderCreate>().SlenderMove();
                    }
					isLight = !isLight;
					msg = getGuiMsg(!isTurn);
					isTurn = !isTurn;
				}
			}
			else
			{
				imageObj.GetComponent<Image>().color = Color.red;
				showInteractMsg = false;
			}
		}

	}
	#region GUI Config

	//configure the style of the GUI
	private void setupGui()
	{
		guiStyle = new GUIStyle();
		guiStyle.fontSize = 16;
		guiStyle.fontStyle = FontStyle.Bold;
		guiStyle.normal.textColor = Color.white;
		msg = "Press Space to turn on";
	}

	private string getGuiMsg(bool isTurn)
	{
		string rtnVal;
		if (isTurn)
		{
			rtnVal = "Press Space to turn off";
		}
		else
		{
			rtnVal = "Press Space to turn on";
		}

		return rtnVal;
	}

	void OnGUI()
	{
		if (showInteractMsg)  //show on-screen prompts to user for guide.
		{
			GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
		}
	}
	//End of GUI Config --------------
	#endregion
}

