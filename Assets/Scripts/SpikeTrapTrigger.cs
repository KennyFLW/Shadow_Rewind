using UnityEngine;

public class SpikeTrapTrigger : MonoBehaviour
{
    public Transform spikeLeft;
    public Transform spikeRight;
    public Transform leftTarget;
    public Transform rightTarget;
    public float speed = 5f;
    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    void Update()
    {
        if (triggered)
        {
            // Di chuyển gai từ hai bên vào giữa
            if (spikeLeft.position.x < leftTarget.position.x)
            {
                spikeLeft.position = Vector2.MoveTowards(spikeLeft.position, leftTarget.position, speed * Time.deltaTime);
            }

            if (spikeRight.position.x > rightTarget.position.x)
            {
                spikeRight.position = Vector2.MoveTowards(spikeRight.position, rightTarget.position, speed * Time.deltaTime);
            }
        }
    }
}
