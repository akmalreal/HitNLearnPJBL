using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Method ini dapat dipanggil dari suatu tombol atau input yang Anda tentukan, misalnya di dalam method untuk tombol exit
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
