using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask enviromentLayer;

    private Rigidbody rb;
    private Animator anim;
    private int jumpCount;
    [SerializeField] private int canMove;

    public MovementData Data { get; set; }
    private float speed
    {
        get
        {
            return Data.Speed;
        }
    }
    private int maxJumps
    {
        get
        {
            return Data.MaxJumps;
        }
    }
    private float jumpForce
    {
        get
        {
            return Data.JumpForce;
        }
    }
    private bool isGrounded
    {
        get
        {
            return Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, 0.50f, enviromentLayer);
            //return Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, 0.15f (MAGNITUD), enviromentLayer);
        }
    }

    public int CanMove
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        canMove = 1;
    }

    private void Update()
    {
        anim.SetBool("IsGrounded", isGrounded);
    }

    public void Move(float x, float y)
    {
        var input = Vector3.ClampMagnitude(new Vector3(x, 0f, y), 1f);
        var mov = input * speed;

        rb.velocity = new Vector3(mov.x, rb.velocity.y, mov.z) * canMove;

        if (input.magnitude > 0.1f && CanMove == 1)
            transform.rotation = Quaternion.LookRotation(input);
        if (isGrounded)
            jumpCount = 0;

        if(canMove == 1 && isGrounded)
            anim.SetFloat("Velocity", input.magnitude);

        rb.angularVelocity = Vector3.zero;
    }

    public void Jump()
    {
        if (jumpCount >= maxJumps - 1) return;
        jumpCount++;
        anim.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }
}