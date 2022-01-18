using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMask : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera myCamera;
    private int rayLayerMask;
    void Start()
    {
        LayerMask iRayLM = LayerMask.NameToLayer("PlayerRaycast");
        myCamera.cullingMask = ~(1 << iRayLM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
