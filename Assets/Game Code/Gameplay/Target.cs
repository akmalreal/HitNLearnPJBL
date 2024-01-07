using UnityEngine;

public class Target : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite; // Gambar target yang baru

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Pastikan tag GameObject bola adalah "Ball"
        {
            spriteRenderer.sprite = newSprite; // Mengubah gambar target menjadi gambar baru
        }
    }
}
