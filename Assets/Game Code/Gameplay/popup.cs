using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour
{
    private Vector2 startPosition = new Vector2(0f, -128f);
    private Vector2 endPosition = Vector2.zero;
    private float showDuration = 1f;
    private float duration = 8f;
    private GameManager2 gameManager;
    public int scoreValue = 1;


    private Collider2D col; // Collider target
    private bool isHit = false; // Menandakan apakah target sudah terkena bola

    private void Start()
    {
        col = GetComponent<Collider2D>(); // Mengambil Collider2D dari GameObject ini
        col.enabled = false; // Mulai dengan menonaktifkan Collider
        gameManager = GameManager2.Instance;
        StartCoroutine(ShowRandom());
    }

    private IEnumerator ShowRandom()
    {
        yield return new WaitForSeconds(Random.Range(0f, 10f)); // Menunda mulai tampil untuk waktu acak

        while (true) // Ulangi proses tampil berulang kali
        {
            StartCoroutine(ShowHide(startPosition, endPosition)); // Mulai animasi tampil dan tunggu hingga selesai
            yield return new WaitForSeconds(Random.Range(20f, 30f)); // Tunggu waktu acak sebelum tampil kembali
        }
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;

        // Mengaktifkan collider saat berada di posisi atas
        col.enabled = true;
        yield return new WaitForSeconds(duration);

        // Menonaktifkan collider saat durasi telah berakhir atau target terkena bola
        col.enabled = false;


        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = start;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Pastikan tag GameObject bola adalah "Ball"
        {
            isHit = true; // Set target sudah terkena bola
            col.enabled = false; // Matikan collider agar tidak bisa terkena bola lagi
        }
        if (gameManager != null)
        {
            gameManager.UpdateScore(scoreValue); // Menambah skor saat target terkena bola
        }
    }
}
