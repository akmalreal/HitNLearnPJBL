using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class kuis : MonoBehaviour
{
    public GameObject panelmateri;
    public GameObject panelkuis;
    public GameObject panelbenar;
    public GameObject panelsalah;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        panelmateri.SetActive(true);
        panelkuis.SetActive(false);
        panelbenar.SetActive(false);
        panelsalah.SetActive(false);
        pause.SetActive(false);
    }
}