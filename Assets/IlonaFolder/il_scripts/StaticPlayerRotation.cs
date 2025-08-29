using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayerRotation : MonoBehaviour
{
    [Header("Look")] public Transform m_cameraHolder;
    [SerializeField] private float m_mouseSensitivity = 2f;
    [SerializeField] private float m_verticalLookLimit = 80f;
    [SerializeField] private float m_verticalRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UpdateController()
    {
        HandleMouseLook();
    }
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        Quaternion tp = transform.rotation;
        Vector3 eu = tp.eulerAngles;
        eu.z = 0;
        transform.eulerAngles = eu;
        m_verticalRotation -= mouseY;
        m_verticalRotation = Mathf.Clamp(m_verticalRotation, -m_verticalLookLimit, m_verticalLookLimit);
        m_cameraHolder.localRotation = Quaternion.Euler(m_verticalRotation, 0f, 0f);
    }
}
