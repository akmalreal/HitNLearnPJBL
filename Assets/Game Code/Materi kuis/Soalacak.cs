using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuisManager : MonoBehaviour
{
    public TextAsset assetSoal;
    public Text pertanyaanText, txtOpsiA, txtOpsiB, txtOpsiC, infoText;
    public GameObject panelBenar, panelSalah;

    private string[] soal;
    private string[,] soalBag;
    private int indexSoal;
    private bool kuisBerjalan = true;
    public int healthPoints = 3;
    public int token = 0;

    void Start()
    {
        BuatDaftarSoal();
        AcakUrutanSoal();
        TampilkanSoal();
    }

    void BuatDaftarSoal()
    {
        soal = assetSoal.text.Split('#');
        soalBag = new string[soal.Length, 5];

        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j];
            }
        }
    }

    void AcakUrutanSoal()
    {
        for (int i = soalBag.GetLength(0) - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            for (int k = 0; k < soalBag.GetLength(1); k++)
            {
                string temp = soalBag[i, k];
                soalBag[i, k] = soalBag[j, k];
                soalBag[j, k] = temp;
            }
        }
    }

    void TampilkanSoal()
    {
        if (indexSoal < soal.Length - 1)
        {
            pertanyaanText.text = soalBag[indexSoal, 0];
            txtOpsiA.text = soalBag[indexSoal, 1];
            txtOpsiB.text = soalBag[indexSoal, 2];
            txtOpsiC.text = soalBag[indexSoal, 3];
        }
        else
        {
            SelesaikanKuis();
        }
    }

    public void JawabanButtonKlik(string jawaban)
    {
        if (kuisBerjalan)
        {
            char pilihan = jawaban[0];
            char kunciJawaban = soalBag[indexSoal, 4][0];

            if (pilihan == kunciJawaban)
            {
                // Jawaban benar
                token++;
                panelBenar.SetActive(true);
                panelSalah.SetActive(false);
            }
            else
            {
                // Jawaban salah
                healthPoints--;
                panelSalah.SetActive(true);
                panelBenar.SetActive(false);

                if (healthPoints <= 0)
                {
                    healthPoints = 0;
                    kuisBerjalan = false;
                    infoText.text = "Game Over! Health Points Habis!";
                    Invoke("Beranda", 2f);
                }
            }
            indexSoal++;
            TampilkanSoal();
        }
    }

    void SelesaikanKuis()
    {
        kuisBerjalan = false;
        infoText.text = "Kuis Selesai! Token Anda: " + token;
        Invoke("KembaliKeMenu", 2f);
    }

    void KembaliKeMenu()
    {
        SceneManager.LoadScene("Beranda");
    }
}
