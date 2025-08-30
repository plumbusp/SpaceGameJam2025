using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Rover : MonoBehaviour
{
    [Header("Speeds")] [SerializeField] private float m_moveSpeed = 1f;
    [SerializeField] private float m_turnSpeed = 45f;

    private Rigidbody m_rb;
    private Coroutine m_activeRoutine;

    public bool IsBusy => m_activeRoutine != null;

    void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        m_rb.interpolation = RigidbodyInterpolation.Interpolate;
        m_rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void Move(float meters)
    {
        StartNewRoutine(MoveRoutine(meters));
    }

    public void Turn(float degrees)
    {
        StartNewRoutine(TurnRoutine(degrees));
    }

    public void Abort()
    {
        if (m_activeRoutine != null) StopCoroutine(m_activeRoutine);
        m_activeRoutine = null;
        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
    }

    public string Status()
    {
        float heading = transform.eulerAngles.y;
        Vector3 p = transform.position;
        return $"POS=({p.x:F1},{p.z:F1}) H={heading:F0}° BUSY={IsBusy}";
    }

    private IEnumerator MoveRoutine(float meters)
    {
        float remaining = Mathf.Abs(meters);
        float dirSign = Mathf.Sign(meters);

        while (remaining > 0f)
        {
            float step = m_moveSpeed * Time.fixedDeltaTime;
            if (step > remaining) step = remaining;

            Vector3 delta = transform.forward * (dirSign * step);
            m_rb.MovePosition(m_rb.position + delta);

            remaining -= step;
            yield return new WaitForFixedUpdate();
        }

        m_activeRoutine = null;
    }

    private IEnumerator TurnRoutine(float degrees)
    {
        float remaining = Mathf.Abs(degrees);
        float sign = Mathf.Sign(degrees);

        while (remaining > 0f)
        {
            float step = m_turnSpeed * Time.deltaTime;
            if (step > remaining) step = remaining;

            transform.Rotate(Vector3.up, step * sign, Space.Self);

            remaining -= step;
            yield return null;
        }

        m_activeRoutine = null;
    }

    private void StartNewRoutine(IEnumerator routine)
    {
        if (m_activeRoutine != null) StopCoroutine(m_activeRoutine);
        m_activeRoutine = StartCoroutine(routine);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 p = Application.isPlaying ? m_rb?.position ?? transform.position : transform.position;
        Gizmos.DrawLine(p, p + transform.forward * 1.0f);
        Gizmos.DrawSphere(p + transform.forward * 1.0f, 0.05f);
    }
#endif
}