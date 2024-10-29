using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    private Vector2 moveInput;
    public LayerMask mask;

    public Transform cameraContainer;
    public float minLook;
    public float maxLook;
    private float camCurRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    public bool canLook = true;

    private Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLook) 
        {
            CameraLook();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = (transform.forward * moveInput.y + transform.right * moveInput.x) * moveSpeed;
        dir.y = rigidbody.velocity.y; // 니가 있는 그상태 그대로의 y값을 넣어주는거, 기존에 남아있는 velocity.y 값이 남아있을수도 있기때문

        rigidbody.velocity = dir; 
    }

    void CameraLook()
    {
        camCurRot += mouseDelta.y * lookSensitivity; //좌우를 보는건 Y축에 대비하여 회전이기 때문에 y의 값을 X에 넣는것
        camCurRot = Mathf.Clamp(camCurRot, minLook, maxLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurRot, 0, 0); // rotation을 돌려볼경우, 음수여야 위쪽을 봄

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); //위아래를 보는건 X축에 대비하여 회전이기때문에 x에 y값
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();

        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;

        }
    }

    public void OnLook(InputAction.CallbackContext context) 
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started) 
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

}
