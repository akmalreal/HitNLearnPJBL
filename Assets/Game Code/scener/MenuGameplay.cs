using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameplay : MonoBehaviour
{
    public void SwitchToScene2()
    {
        SceneManager.LoadScene("Gameplay");

    }
}
