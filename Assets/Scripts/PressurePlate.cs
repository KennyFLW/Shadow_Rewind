using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorController door;
    public float delayBeforeClose = 1f;
    private bool playerOnPlate = false;
    private float timer = 0f;

    // Hình ảnh của nút
    public Sprite defaultSprite;
    public Sprite pressedSprite;
    private SpriteRenderer spriteRenderer;

    // Âm thanh
    private AudioSource audioSource;
    public AudioClip pressSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;

        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            playerOnPlate = true;
            door.OpenDoor();

            // Đổi sprite thành khi bị nhấn
            spriteRenderer.sprite = pressedSprite;

            // ✅ Phát âm thanh
            if (pressSound != null)
            {
                audioSource.PlayOneShot(pressSound);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            playerOnPlate = false;
            timer = delayBeforeClose;

            // Trở lại sprite ban đầu
            spriteRenderer.sprite = defaultSprite;
        }
    }

    void Update()
    {
        if (!playerOnPlate && timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                door.CloseDoor();
            }
        }
    }
}
