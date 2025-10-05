using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeReset : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ResetAfterSoundPaused());
        }
    }

    private System.Collections.IEnumerator ResetAfterSoundPaused()
    {
        Time.timeScale = 0f;  // ✅ Tạm dừng game

        if (hitSound != null)
            audioSource.PlayOneShot(hitSound);

        // ✅ Dùng thời gian thực tế (unscaled time) để chờ âm thanh
        float waitTime = (hitSound != null) ? hitSound.length : 0.5f;
        yield return new WaitForSecondsRealtime(waitTime);

        Time.timeScale = 1f;  // Khôi phục game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
