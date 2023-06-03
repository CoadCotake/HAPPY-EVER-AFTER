using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_TwoButton : MonoBehaviour
{
    public GameObject TwoPlant;
    public GameObject MiniDoor1;
    public GameObject MiniDoor2;

    public void TwoAnswer1()
    {
        SceneManager.LoadScene("Game Start");
    }
    public void TwoAnswer2()
    {
        SceneManager.LoadScene("Game Start");

    }
    public void TwoAnswer3()
    {
        Destroy(TwoPlant);
        Destroy(MiniDoor1);
        Destroy(MiniDoor2);

    }
}
