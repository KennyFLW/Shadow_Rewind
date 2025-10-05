using UnityEngine;

public class DoorWithTimedButtons : MonoBehaviour
{
    public TimedButton buttonA;
    public TimedButton buttonB;
    public Transform openPosition;
    public Transform closePosition;
    public float moveSpeed = 2f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 targetPos = (buttonA.isPressed && buttonB.isPressed) ? openPosition.position : closePosition.position;

        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}
