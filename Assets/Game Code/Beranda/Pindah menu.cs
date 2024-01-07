using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject settingpanel;
    public GameObject materipanel;
    public GameObject marketpanel;
    // Start is called before the first frame update
    void Start()
    {
        menupanel.SetActive(true);
        settingpanel.SetActive(false);
        materipanel.SetActive(false);
        marketpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton (string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void InfoButton()
    {
        menupanel.SetActive(false);
        settingpanel.SetActive(true);
        materipanel.SetActive(false);
        marketpanel.SetActive(false);
    }

    public void MateriButton()
    {
        menupanel.SetActive(false);
        settingpanel.SetActive(false);
        materipanel.SetActive(true);
        marketpanel.SetActive(false);

    }
    public void MarketButton()
    {
        menupanel.SetActive(false);
        settingpanel.SetActive(false);
        materipanel.SetActive(false);
        marketpanel.SetActive(true);
    }
}
