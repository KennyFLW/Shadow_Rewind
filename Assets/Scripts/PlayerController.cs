using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float horizontalInput;
    private Rigidbody2D rb;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public PhysicsMaterial2D AirMaterial;

    public AudioClip jumpSound; // 👈 Âm thanh nhảy
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Update()
    {
        // Move
        horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
        rb.sharedMaterial = AirMaterial;

        // Jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGround())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound); // 👈 Phát âm thanh khi nhảy
            }
        }
    }

    public bool isGround()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
