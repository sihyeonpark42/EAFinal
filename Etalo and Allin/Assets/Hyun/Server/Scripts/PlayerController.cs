using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{

 
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    float verticalLookRotation;

    bool grounded;
    bool isContect = false;
    bool isInteract = false;
    float h;
    float v;
 

    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Rigidbody rb;

    PhotonView PV;

    Animator animator;

    //PlayerManager playerManager;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();

       // playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    void Start()
    {
        if (PV.IsMine)

        {
            // EquipItem(0);
        }

        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            //Destroy(animator);
            // Destroy(ui);
           // Destroy(animator);
        }

      
    }

    void Update()
    {
        if (!PV.IsMine)
            return;

        Look();

        Move();

        Jump();



    }

    void Look()
    {
    
        //transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        //verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        //verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

       // cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");

        //if (h != 0)
        //{
        //    if (h > 0)
        //    {
        //        //Debug.Log("in MoveR Flow!");
        //        animator.SetTrigger("run");
        //    }
        //    else if (h < 0)
        //    {
        //        //Debug.Log("in MoveL Flow!");
        //        animator.SetTrigger("run");
        //    }
        //}

        //if (v != 0)
        //{
        //    if (v > 0)
        //    {
        //        //Debug.Log("in run Flow!");
        //        animator.SetTrigger("run");
        //    }
        //    else if (v < 0)
        //    {
        //        //Debug.Log("in runBack Flow!");
        //        animator.SetTrigger("run");
        //    }
        //}

        //if (h == 0 && v == 0)
        //{
        //    animator.ResetTrigger("run");
        //    animator.SetTrigger("idle");
        //}

    



        //Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }



    void Jump()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && grounded)
        //{
        //    rb.AddForce(transform.up * jumpForce);
        //    animator.SetTrigger("jump");
        //    Debug.Log("Jump");
            
        //}


    }



    void FixedUpdate()
    {

        if (!PV.IsMine)
            return;


        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

       
       
    }

}