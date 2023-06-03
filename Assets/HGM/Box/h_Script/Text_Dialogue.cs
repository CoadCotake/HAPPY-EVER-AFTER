using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite cg;
}

public class Text_Dialogue : MonoBehaviour {

    [SerializeField] private Image sprite_CG;
    [SerializeField] private Image sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialogue[] dialogues;
    Ending_Manager Ending_Manager;
    PlayerControl PlayerControl;

    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        NextDialogue(1);
    }
	
    private void NextDialogue(int a)
    {
        if(a == 1)
        {
            txt_Dialogue.text = dialogues[count].dialogue;
            sprite_CG.sprite = dialogues[count].cg;
            count++;
        }
        else if(a == 0)
        {
            count--;
            txt_Dialogue.text = dialogues[count].dialogue;
            sprite_CG.sprite = dialogues[count].cg;
        }
        
    }
	
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_CG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }
	void Update ()
    {
		if(isDialogue)
        {
            if(Input.GetKeyDown("z"))
            {
                if (count < dialogues.Length)
                    NextDialogue(1);
                else
                {
                    OnOff(false);
                    PlayerControl.pause = false;
                    Ending_Manager.End = 1;
                }  
            }
            else if (Input.GetKeyDown("x") && count > 0)
            {
                NextDialogue(0);
            }
        }
	}
}
