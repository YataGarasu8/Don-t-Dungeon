using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]//Unity의 Inspector 창에서 변수를 그룹화하고 가독성을 높이는 속성(Attribute)
    public float moveSpeed;//이동 속도
    public float jumpForce;//점프력
    private Vector2 curMoveMentInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;//최소X값
    public float maxXLook;//최대X값
    public float lookSensitivity;//민감도
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
        Cursor.lockState = CursorLockMode.Locked;// 마우스의 위치를 고정
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
        dir.y = _rigidbody.velocity.y;//y값 초기화

        _rigidbody.velocity = dir;
    }
    public void OnMove(InputAction.CallbackContext callbackContext)//callbackContext로 현재 상태를 받아올 수 있음
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
            if (Physics.Raycast(rays[i], 0.65f, groundLayerMask))//점프가 안되면 0.65f(검출 길이)를 조절
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
