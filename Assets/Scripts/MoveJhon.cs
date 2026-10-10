using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem; // Importante: agregar esta librería

public class MoveJhon : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float JumpForce;
    private bool Grounded;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = 0f;

        

        // Verificamos si hay un teclado conectado
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                horizontal = -1f;
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                horizontal = 1f;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        animator.SetBool("Running", horizontal != 0.0f);

        //Un solo salto
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
            Grounded = true;
        else
            Grounded = false;

        // Salto con W o Flecha Arriba (equivalente a GetKeyDown)
        if ((Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame) && Grounded)
        {
            Jump();
        }

        //Version vieja
        //if (Input.GetKeyDown(KeyCode.W))
        //    Jump();

    }

    //Saltar
    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        // En Unity 6+: linearVelocity
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);

        //Version vieja 
        //Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
