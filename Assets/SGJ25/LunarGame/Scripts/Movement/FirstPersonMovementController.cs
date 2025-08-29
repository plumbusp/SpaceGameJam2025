using UnityEngine;

namespace SGJ25.LunarGame.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonMovementController : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float m_moveSpeed = 6f;
        [SerializeField] private float m_gravity = -9.81f;
        [SerializeField] private float m_jumpHeight = 1.5f;
        [Header("Look")] public Transform m_cameraHolder;
        [SerializeField] private float m_mouseSensitivity = 2f;
        [SerializeField] private float m_verticalLookLimit = 80f;
        [SerializeField] private CharacterController m_controller;
        [SerializeField] private Vector3 m_velocity;
        [SerializeField] private float m_verticalRotation = 0f;
        [SerializeField] private bool m_update;

        private void Awake()
        {
            Initialise();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (m_update) UpdateController();
        }

        public void Initialise()
        {
            m_controller = GetComponent<CharacterController>();
        }

        public void UpdateController()
        {
            HandleMovement();
            HandleMouseLook();
        }

        void HandleMovement()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            m_controller.Move(move * m_moveSpeed * Time.deltaTime);

            m_velocity.y += m_gravity * Time.deltaTime;
            m_controller.Move(m_velocity * Time.deltaTime);
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
}