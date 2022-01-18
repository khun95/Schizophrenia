using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharctorMove : MonoBehaviour
{

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;
    public float currentCameraRotationY;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;
    public Animator animator;
    public AudioSource audioSource;

    public float v = 0.0f;
    public float h = 0.0f;
    public float moveSpeed = 3.0f;
    public Transform PlayerTr;
    public GameObject head;
    
    public Vector3 cameraRotateOffset = new Vector3(290.428833f, 322.577545f, 26.4789619f);

    public bool isSit = false;
    private Camera fpsCam;

    private bool isCol = false;

    public GameObject gameManager;
    public bool isMove = false;

    private GameObject imageObj;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        fpsCam = Camera.main;
        imageObj = GameObject.FindGameObjectWithTag("TargetImage");
    }

    // Update is called once per frame
    void Update()
    {
        isMove = gameManager.GetComponent<GameManager>().charctorMove;
        if (isMove)
        {
            Move();
            CharacterSit();
            CameraRotation();
            CharacterRotation();
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Object")
        {
            isCol = true;
            animator.SetFloat("v", 0);
            myRigid.velocity = new Vector3(0,1,1);
        }
    }
    void OnTriggerExit(Collider other)
    {
        isCol = false;
        myRigid.velocity = Vector3.zero;
        myRigid.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        if (!isCol)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            if (v != 0)
            {
                animator.SetFloat("v", v);
            }
            else if (h != 0)
            {
                animator.SetFloat("v", h);
            }
            PlayerTr.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        }
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        float MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * lookSensitivity * MouseX);
    }

    private void CharacterSit()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("IsSit", !isSit);
            isSit = !isSit;
            Debug.Log(isSit);
        }
    }
    public void AudioPlay()
    {
        audioSource.Play();
        //StartCoroutine(AudioplayCor());
        Debug.Log("Walk");
    }

    IEnumerator AudioplayCor()
    {
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        audioSource.Play();
    }
    public void AudioStop()
    {
        Debug.Log("stop");
        audioSource.Stop();
    }
}
