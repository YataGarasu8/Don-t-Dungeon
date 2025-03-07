using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]//Unity�� Inspector â���� ������ �׷�ȭ�ϰ� �������� ���̴� �Ӽ�(Attribute)
    public float moveSpeed;//�̵� �ӵ�
    public float jumpForce;//������
    private Vector2 curMoveMentInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;//�ּ�X��
    public float maxXLook;//�ִ�X��
    public float lookSensitivity;//�ΰ���
    float camCurXRot;
    Vector2 mouseDelta;
    

    public Rigidbody _rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;// ���콺�� ��ġ�� ����
    }
    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {

    }
    private void LateUpdate()
    {
        CameraLook();
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMoveMentInput.y + transform.right * curMoveMentInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;//y�� �ʱ�ȭ

        _rigidbody.velocity = dir;
    }
    public void OnMove(InputAction.CallbackContext callbackContext)//callbackContext�� ���� ���¸� �޾ƿ� �� ����
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            curMoveMentInput = callbackContext.ReadValue<Vector2>();
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            curMoveMentInput = Vector2.zero;
        }
    }
    public void OnLook(InputAction.CallbackContext callbackContext)
    {
        mouseDelta = callbackContext.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.phase == InputActionPhase.Started && IsGround())
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position +(transform.forward*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position +(-transform.forward*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position +(transform.right*0.2f)+(transform.up*0.01f),Vector3.down),
            new Ray(transform.position +(-transform.right*0.2f)+(transform.up*0.01f),Vector3.down)
        };
        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.65f, groundLayerMask))//������ �ȵǸ� 0.65f(���� ����)�� ����
            {
                return true;
            }
        }
        return false;
    }
    public void BoostJumpForce(float boost)
    {
        jumpForce += boost;
    }
    public void RollBackJumpForce(float boost)
    {
        jumpForce -= boost;
    }
}
