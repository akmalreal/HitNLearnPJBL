using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D col;

    // Properti tambahan untuk posisi
    public Vector3 pos { get { return transform.position; } }
    private Vector3 startPosition;
    private Vector3 startScale;

    public float shrinkRate = 0.1f;
    public float minSize = 0.1f;
    public float stopDuration = 1f;
    public float respawnDelay = 2f; // Waktu penundaan sebelum bola muncul kembali

    private bool isLaunched = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.gravityScale = 0f;
        startPosition = transform.position;
        startScale = transform.localScale;
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        rb.gravityScale = 1f;
        isLaunched = true; // Menandakan bahwa bola telah diluncurkan
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target")) // Pastikan tag GameObject target adalah "Target"
        {
            rb.velocity = Vector2.zero; // Menghentikan pergerakan bola
            rb.gravityScale = 0f; // Menghapus gravitasi bola
            col.enabled = false; // Menonaktifkan collider untuk sementara waktu
            Invoke("ResetBall", stopDuration); // Menjalankan fungsi ResetBall() setelah 1 detik
        }
    }

    private void ResetBall()
    {
        transform.position = startPosition; // Atur ulang posisi bola ke posisi awal
        transform.localScale = startScale; // Atur ukuran bola ke ukuran awal
        col.enabled = true; // Aktifkan kembali collider
        rb.gravityScale = 0f; // Ubah kembali gravitasi bola
        gameObject.SetActive(true); // Aktifkan kembali bola


        // Setelah sejumlah waktu, nonaktifkan kembali bola
        Invoke("DisableBall", respawnDelay);
    }

    private void DisableBall()
    {
        gameObject.SetActive(false); // Menonaktifkan bola
    }

    private void Update()
    {
        if (isLaunched)
        {
            // Mengurangi skala bola secara perlahan
            float newSize = Mathf.Max(transform.localScale.x - shrinkRate * Time.deltaTime, minSize);
            transform.localScale = new Vector3(newSize, newSize, 1f);

            // Setelah mencapai ukuran minimum, hentikan perubahan ukuran
            if (newSize <= minSize)
            {
                gameObject.SetActive(false); // Menonaktifkan bola
                Invoke("ResetBall", 1f); // Munculkan kembali bola setelah beberapa detik
            }
        }
    }
}
