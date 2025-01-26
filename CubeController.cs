using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 20f; // ����������� ���� ������
    public float rotationSpeed = 100f;
    public Transform cameraTransform;
    public float cameraDistance = 5f;
    public float cameraHeight = 2f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ��������
        float moveInput = Input.GetAxis("Vertical"); // ������� W � S
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.position += moveDirection;

        // ������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("������!"); // ��� ��� �������� ������
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); // �������� �� VelocityChange
            isGrounded = false;
        }

        // �������� �����
        if (Input.GetMouseButton(0)) // ����� ������ ����
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, mouseX);
        }

        // ������ ������� �� �����
        if (cameraTransform != null)
        {
            Vector3 cameraOffset = -transform.forward * cameraDistance + Vector3.up * cameraHeight;
            cameraTransform.position = transform.position + cameraOffset;
            cameraTransform.LookAt(transform);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("�� �����!"); // ��� ��� �������� ������������ � �����
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("�� �� �����!"); // ��� ��� �������� ������ �� �����
        }
    }
}