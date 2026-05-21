using UnityEngine;

public class DashPad : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private string dashDirection = "up";

    [SerializeField] private float dashForce = 20f;

    private void Awake()
    {
        
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlayJumpSound();
            Rigidbody2D rb =
                collision.GetComponent<Rigidbody2D>();

            Vector2 direction = Vector2.right;

            if (dashDirection == "right")
            {
                direction = Vector2.right;
            }
            else if (dashDirection == "left")
            {
                direction = Vector2.left;
            }
            else if (dashDirection == "up")
            {
                direction = Vector2.up;
            }

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(
                direction * dashForce,
                ForceMode2D.Impulse
            );
        }
    }
}
