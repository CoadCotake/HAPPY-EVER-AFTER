using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_Button : MonoBehaviour
{

    public GameObject OnePlant;
    public GameObject BD1;
    public GameObject BD2;
    public GameObject BD3;
    public GameObject BD4;


    public void BridgeSet()
    {
       
        BD1.gameObject.SetActive(true);
        BD2.gameObject.SetActive(true);
        BD3.gameObject.SetActive(true);
        BD4.gameObject.SetActive(true);
    }
    

    public void OneAnswer1()
    {
        Destroy(OnePlant);
        StartCoroutine("BridgeSet");
        BridgeSet();
    }

    public void OneAnswer2()
    {
        SceneManager.LoadScene("Game Start");
    }

    public void OneAnswer3()
    {
        SceneManager.LoadScene("Game Start");
    }

    public void OneAnswer4()
    {
        SceneManager.LoadScene("Game Start");
    }
}
