using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DollScript : MonoBehaviour
{
	private float reachRange = 2f;
	private bool playerEntered;
	private bool showInteractMsg;

	private Animator anim;
	private Camera fpsCam;
	private GameObject player;
	private GUIStyle guiStyle;
	private string msg;
	private bool isOpen;
	private int rayLayerMask;
	private GameObject gamemanager;
	private GameObject imageObj;
	private AudioSource audioSource;


	// Start is called before the first frame update
	void Start()
    {
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Player");
		fpsCam = Camera.main;
		if (fpsCam == null) //a reference to Camera is required for rayasts
		{
			Debug.LogError("A camera tagged 'MainCamera' is missing.");
		}

		gamemanager = GameObject.Find("GameManager");
		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;
		audioSource = GameObject.Find("DollSoundManager").GetComponent<AudioSource>();
		//setup GUI style settings for user prompts
		setupGui();
		imageObj = GameObject.FindGameObjectWithTag("TargetImage");
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")     //player has collided with trigger
		{
			playerEntered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")     //player has exited trigger
		{
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (playerEntered)
		{

			//center point of viewport in World space.
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			Debug.DrawRay(rayOrigin, fpsCam.transform.forward * reachRange, Color.red);
			if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
			{
				//is the object of the collider player is looking at the same as me?
				showInteractMsg = true;
				imageObj.GetComponent<Image>().color = Color.green;
				msg = getGuiMsg(isOpen);

				if (Input.GetKeyUp(KeyCode.Space)){
					audioSource.Play();
					gamemanager.GetComponent<GameManager>().clearCount++;
					Destroy(gameObject);
					imageObj.GetComponent<Image>().color = Color.red;
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
		msg = "Press Space to Get Item";
	}

	private string getGuiMsg(bool isOpen)
	{
		string rtnVal;
		if (isOpen)
		{
			rtnVal = "Press Space to Get Item";
		}
		else
		{
			rtnVal = "Press Space to Get Item";
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
