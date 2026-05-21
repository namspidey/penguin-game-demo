using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cookie"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCookieSound();
            gameManager.AddScore(1);
            gameManager.CollectCookie(); // ← MỚI
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Enemy"))
        {
            audioManager.PlayDoroKillSound();
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            if (!gameManager.AllCookiesCollected()) return; // ← MỚI: chặn nếu chưa đủ Cookie

            Destroy(collision.gameObject);
            audioManager.PlayWinSound();
            gameManager.GameWin();
        }
    }
}
