using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleWaypoint : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject targetObject; // L'objet à activer/déplacer
    [SerializeField] private float maxRayDistance = 100f;
    [SerializeField] private LayerMask raycastLayers; // Couches détectables
    private InputAction Trigger;
    public InputActionAsset InputActions;
    private void Awake()
    {
        Trigger = InputActions.FindActionMap("Player").FindAction("WayPoint");
    }

    public void OnEnable()
    {
        Trigger.performed += OnWaypoint;
        Trigger.Enable();
    }
    public void OnDisable()
    {
        Trigger.performed -= OnWaypoint;
        Trigger.Disable();

    }


    void OnWaypoint(InputAction.CallbackContext context)
    {
        if (!targetObject.activeSelf)
        {
            targetObject.SetActive(true);
        }

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRayDistance, raycastLayers))
        {
            targetObject.transform.position = hitInfo.point;
        }
    }
}
