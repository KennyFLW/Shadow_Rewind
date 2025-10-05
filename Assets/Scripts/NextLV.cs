using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLV : MonoBehaviour
{
    public AudioClip triggerSound;             // Âm thanh khi chạm
    private AudioSource audioSource;
    private bool hasTriggered = false;         // Tránh kích hoạt nhiều lần

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag("Player"))
        {
            hasTriggered = true;

            float soundDuration = 0.1f;
            if (triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
                soundDuration = triggerSound.length;  // ⏳ Lấy thời gian âm thanh
            }

            StartCoroutine(LoadNextSceneAfterDelay(soundDuration));
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // ⏳ Chờ phát xong âm thanh
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
