using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public Rigidbody2D spikeRb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Cho phép gai rơi xuống bằng cách chuyển sang Dynamic
            spikeRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
