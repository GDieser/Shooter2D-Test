using UnityEngine;
using UnityEngine.InputSystem; // Importante: agregar esta librería

public class MoveJhon : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = 0f;

        // Verificamos si hay un teclado conectado
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                horizontal = -1f;
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                horizontal = 1f;
        }
    }

    private void FixedUpdate()
    {
        // En Unity 6+: linearVelocity
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }
}
