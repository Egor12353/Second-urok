using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 20f; // Увеличенная сила прыжка
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
        // Движение
        float moveInput = Input.GetAxis("Vertical"); // Клавиши W и S
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.position += moveDirection;

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Прыжок!"); // Лог для проверки прыжка
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); // Изменено на VelocityChange
            isGrounded = false;
        }

        // Вращение мышью
        if (Input.GetMouseButton(0)) // Левая кнопка мыши
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, mouseX);
        }

        // Камера следует за кубом
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
            Debug.Log("На земле!"); // Лог для проверки столкновения с землёй
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Не на земле!"); // Лог для проверки отрыва от земли
        }
    }
}