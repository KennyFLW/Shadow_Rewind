using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shadowPrefab;         // Prefab bóng mờ
    private GameObject currentShadowObj;    // GameObject của bóng hiện tại

    public AudioClip shadowSetClip;         // Âm thanh khi đặt bóng
    public AudioClip rewindClip;            // Âm thanh khi tua lại
    private AudioSource audioSource;        // Audio Source để phát âm

    private Vector3 savedPosition;
    private bool hasShadow = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>(); // Tự thêm nếu chưa có
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!hasShadow)
            {
                SetShadow();
            }
            else
            {
                RewindToShadow();
            }
        }
    }

    void SetShadow()
    {
        savedPosition = transform.position;
        hasShadow = true;

        if (currentShadowObj != null)
            Destroy(currentShadowObj);

        currentShadowObj = Instantiate(shadowPrefab, savedPosition, Quaternion.identity);

        if (shadowSetClip != null)
            audioSource.PlayOneShot(shadowSetClip);

        Debug.Log("Shadow set at: " + savedPosition);
    }

    void RewindToShadow()
    {
        if (!hasShadow) return;

        Vector2 currentVelocity = rb.linearVelocity;

        transform.position = savedPosition;
        rb.linearVelocity = currentVelocity;

        hasShadow = false;

        if (currentShadowObj != null)
            Destroy(currentShadowObj);

        if (rewindClip != null)
            audioSource.PlayOneShot(rewindClip);

        Debug.Log("Rewound to shadow!");
    }
}
