using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    
    private Vector2 moveInput;
    private Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movement = moveInput * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        Debug.Log($"Player: Moving with input {moveInput}, velocity: {movement}");
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Player: Moving with input {moveInput}");
    }

    private void RotatePlayer()
    {
        // Получаем позицию мыши в мировых координатах
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        // Рассчитываем направление от игрока к мыши
        Vector2 direction = mousePosition - rb.position;
        
        // Рассчитываем угол в радианах, а затем переводим в градусы
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        
        // Плавно поворачиваем игрока к мыши
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        
        Debug.Log($"Player: Rotating towards mouse at {mousePosition}, angle: {angle}");
    }
    
}
