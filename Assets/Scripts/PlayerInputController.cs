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
        dir.y = rigidbody.velocity.y; // �ϰ� �ִ� �׻��� �״���� y���� �־��ִ°�, ������ �����ִ� velocity.y ���� ������������ �ֱ⶧��

        rigidbody.velocity = dir; 
    }

    void CameraLook()
    {
        camCurRot += mouseDelta.y * lookSensitivity; //�¿츦 ���°� Y�࿡ ����Ͽ� ȸ���̱� ������ y�� ���� X�� �ִ°�
        camCurRot = Mathf.Clamp(camCurRot, minLook, maxLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurRot, 0, 0); // rotation�� ���������, �������� ������ ��

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); //���Ʒ��� ���°� X�࿡ ����Ͽ� ȸ���̱⶧���� x�� y��
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
