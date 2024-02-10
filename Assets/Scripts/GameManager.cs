using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;
    public Text scoreText;
    public GameObject ballPrefab;
    public Transform spawnPoint;

    void Awake()
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

    void Update()
    {
        if (GetBallCount() == 0)
        {
            LoseLife();
            SpawnBall();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Puntuación: " + score;

        CheckLevelComplete();
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }

    int GetBallCount()
    {
        return GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    void CheckLevelComplete()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }
}
