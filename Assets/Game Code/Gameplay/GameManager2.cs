using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;
    public Text scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreUI();

        if (score >= 3)
        {
            LoadNextScene(); // Call the function to load the next scene
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void LoadNextScene()
    {
        // Load the next scene by its build index
        // Replace 'YourNextSceneIndex' with the build index of your next scene
        SceneManager.LoadScene("kuismateri");
    }
}
