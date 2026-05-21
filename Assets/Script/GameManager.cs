using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gamePauseUI;

    private bool isGameOver = false;
    private bool isGameWin = false;
    private bool isPaused = false;

    private int totalCookies = 0;      // ← MỚI
    private int collectedCookies = 0;  // ← MỚI

    void Start()
    {
        totalCookies = GameObject.FindGameObjectsWithTag("Cookie").Length; // ← MỚI
        UpdateScore();
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        gamePauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGameOver && !isGameWin)
            {
                TogglePause();
            }
        }
    }

    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateScore();
        }
    }

    // ── MỚI ──────────────────────────────────────────
    public void CollectCookie()
    {
        collectedCookies++;
        score = collectedCookies; // giữ score đồng bộ nếu cần dùng sau
        UpdateScore();
    }

    public bool AllCookiesCollected()
    {
        return collectedCookies >= totalCookies;
    }
    // ─────────────────────────────────────────────────

    private void UpdateScore()
    {
        scoreText.text = $"{collectedCookies}/{totalCookies}";
    }

    public void GameOver()
    {
        Debug.Log("game over");
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("restart");
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver() => isGameOver;
    public bool IsGameWin() => isGameWin;

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            gamePauseUI.SetActive(true);
        }
        else
        {
            ContinueGame();
        }
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        gamePauseUI.SetActive(false);
    }


}