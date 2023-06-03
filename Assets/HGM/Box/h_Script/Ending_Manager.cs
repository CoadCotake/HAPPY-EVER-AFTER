using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Manager : MonoBehaviour
{
    public Text_Dialogue Text_Dialogue1;
    public Text_Dialogue Text_Dialogue2;
    public static int End = 0;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Text_Dialogue1.ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(End == 1 && count == 0)
        {
            Invoke("Ending_Dialogue", 3);
            count++;
        }
    }

    void Ending_Dialogue()
    {
        Text_Dialogue2.ShowDialogue();
    }
}
