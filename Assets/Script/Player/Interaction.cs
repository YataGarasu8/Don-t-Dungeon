using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    public float maxCheckDistance;
    float lastCheckTime;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    Camera rayCamera;

    void Start()
    {
        rayCamera = Camera.main;
    }
    void Update()
    {
        ObjectCheck();
    }
    void ObjectCheck()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            Ray ray = rayCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }
    void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }
    public void OnInteractInput(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
    void OnDrawGizmos()
    {
        if (rayCamera == null) return;

        Ray ray = rayCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin,ray.origin);

        // Ray가 충돌한 곳에 빨간색 Sphere를 그림
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 0.1f); // 충돌 지점에 작은 구체 표시
        }
    }

}
