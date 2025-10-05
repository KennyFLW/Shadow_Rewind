using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform openPosition;
    public Transform closePosition;
    public float moveSpeed = 2f;
    private bool shouldOpen = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 targetPos = shouldOpen ? openPosition.position : closePosition.position;

        // Kiểm tra nếu chưa tới vị trí thì di chuyển và bật âm
        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            // Đã tới nơi, dừng âm thanh
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }

    public void OpenDoor()
    {
        shouldOpen = true;
    }

    public void CloseDoor()
    {
        shouldOpen = false;
    }
}
