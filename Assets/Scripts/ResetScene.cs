using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    // Hàm để gọi khi bấm nút
    public void ResetCurrentScene()
    {
        // Lấy index scene hiện tại và tải lại
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
