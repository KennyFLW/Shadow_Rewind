using UnityEngine;

public class TimedButton : MonoBehaviour
{
    public Sprite unpressedSprite;
    public Sprite pressedSprite;
    private SpriteRenderer spriteRenderer;

    public bool isPressed = false;
    public float pressDuration = 2f;
    private float timer = 0f;

    private int pressCount = 0; // Đếm số vật đang đè lên nút

    // Âm thanh
    private AudioSource audioSource;
    public AudioClip pressSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unpressedSprite;

        // Lấy AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Nếu không còn vật nào đứng trên nút và đang trong trạng thái pressed
        if (pressCount == 0 && isPressed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isPressed = false;
                spriteRenderer.sprite = unpressedSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            pressCount++;

            // Nếu là lần nhấn đầu
            if (!isPressed)
            {
                isPressed = true;
                spriteRenderer.sprite = pressedSprite;

                // ✅ Phát âm thanh
                if (audioSource != null && pressSound != null)
                {
                    audioSource.PlayOneShot(pressSound);
                }
            }

            // Reset timer khi vật quay lại nút
            timer = pressDuration;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            pressCount--;
            if (pressCount <= 0)
            {
                pressCount = 0; // đảm bảo không âm
                timer = pressDuration;
            }
        }
    }
}
