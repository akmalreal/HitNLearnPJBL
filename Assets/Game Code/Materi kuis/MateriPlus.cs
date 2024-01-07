using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{
    public TextAsset assetMateri;
    public RawImage gambarMateri;
    public Text teksMateri;

    private string[] materi;
    private int indexMateri;

    void Start()
    {
        materi = assetMateri.ToString().Split('#');
        TampilkanMateri();
    }

    void TampilkanMateri()
    {
        if (indexMateri < materi.Length - 1)
        {
            string[] dataMateri = materi[indexMateri].Split('+');
            teksMateri.text = dataMateri[0];

            // Mengganti gambar materi (ganti "nama_gambar" dengan nama gambar sesuai dengan aset Anda)
            Texture2D texture = Resources.Load<Texture2D>("nama_gambar");
            gambarMateri.texture = texture;
        }
        else
        {
            // Menampilkan pesan jika sudah mencapai akhir materi
            teksMateri.text = "Ini adalah akhir dari materi.";
            gambarMateri.texture = null;
        }
    }

    public void MateriSelanjutnya()
    {
        indexMateri++;
        TampilkanMateri();
    }

    public void MateriSebelumnya()
    {
        if (indexMateri > 0)
        {
            indexMateri--;
            TampilkanMateri();
        }
    }
}
