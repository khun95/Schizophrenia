using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool charctorMove = false;

    public Camera playerCamera;
    public Camera startCamera;
    public GameObject player;

    private float ratio = 0;

    private Vector3 startPos = new Vector3(2.72399998f, 0.878000021f, -7.421f);
    private Vector3 endPos = new Vector3(2.7190001f, 0.175999999f, -6.27799988f);
    // Start is called before the first frame update

    public int clearCount = 0;
    public TextMeshProUGUI ScriptTxt;
    public GameObject text;

    void Start()
    {
        StartCoroutine(CameraSwitch());
        ScriptTxt = text.GetComponent<TextMeshProUGUI>();
        ScriptTxt.text = "Count : " + clearCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       ScriptTxt.text = "Count : " + clearCount.ToString();
    }


    IEnumerator CameraSwitch()
    {

        while(true)
        {
            player.transform.position = Vector3.Lerp(startPos, endPos, ratio);

            ratio += 0.008f;
            yield return null;
            if (ratio >= 1)
                break;
        }
        yield return new WaitForSeconds(2.5f);
        playerCamera.targetDisplay = 0;
        startCamera.targetDisplay = 1;
        charctorMove = true;
    }

}
