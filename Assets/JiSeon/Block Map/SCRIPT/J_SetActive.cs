using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_SetActive : MonoBehaviour
{
    // 퀴즈 맵 시작할 때 말풍선 나오는 부분
    public GameObject speech_bubble;
    public GameObject speech_bubble_text;
    public GameObject PlantPicture;
    public GameObject PlayerPicture;


    //1번 퀴즈
    public GameObject PanelImage1;
    public GameObject QuizImage1;
    public Text QuizText1;
    public Button OneAnswer1;
    public Button OneAnswer2;
    public Button OneAnswer3;
    public Button OneAnswer4;

    //2번 퀴즈
    public GameObject PanelImage2;
    public GameObject PanelImage2_1;
    public Text SubQuiz1;
    public Text SubQuiz2;
    public Text SubQuiz3;
    public Text SubQuiz4;
    public Text SubQuiz5;
    public Text SubQuiz6;
    public Text QuizText2;
    public Button Answer2_1;
    public Button Answer2_2;
    public Button Answer2_3;
    public GameObject EX1;
    public GameObject EX2;
    public GameObject EX3;
    public GameObject EX4;
    public GameObject EX5;
    public GameObject EX6;

   



    void Start()
    {
        speech_bubble.gameObject.SetActive(false);
        speech_bubble_text.gameObject.SetActive(false);

        PanelImage1.gameObject.SetActive(false);
        QuizImage1.gameObject.SetActive(false);
        QuizText1.gameObject.SetActive(false);
        OneAnswer1.gameObject.SetActive(false);
        OneAnswer2.gameObject.SetActive(false);
        OneAnswer3.gameObject.SetActive(false);
        OneAnswer4.gameObject.SetActive(false);

        PanelImage2.gameObject.SetActive(false);
        PanelImage2_1.gameObject.SetActive(false);
        SubQuiz1.gameObject.SetActive(false);
        SubQuiz2.gameObject.SetActive(false);
        SubQuiz3.gameObject.SetActive(false);
        SubQuiz4.gameObject.SetActive(false);
        SubQuiz5.gameObject.SetActive(false);
        SubQuiz6.gameObject.SetActive(false);
        QuizText2.gameObject.SetActive(false);
        Answer2_1.gameObject.SetActive(false);
        Answer2_2.gameObject.SetActive(false);
        Answer2_3.gameObject.SetActive(false);
        EX1.gameObject.SetActive(false);
        EX2.gameObject.SetActive(false);
        EX3.gameObject.SetActive(false);
        EX4.gameObject.SetActive(false);
        EX5.gameObject.SetActive(false);
        EX6.gameObject.SetActive(false);

        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hint"))
        {
            speech_bubble.gameObject.SetActive(true);
            speech_bubble_text.gameObject.SetActive(true);
            PlantPicture.gameObject.SetActive(true);
            PlayerPicture.gameObject.SetActive(true);
        }

        if (collision.CompareTag("Quiz"))
        {
            QuizImage1.gameObject.SetActive(true);
            QuizText1.gameObject.SetActive(true);
            PanelImage1.gameObject.SetActive(true);
            //버튼
            OneAnswer1.gameObject.SetActive(true);
            OneAnswer2.gameObject.SetActive(true);
            OneAnswer3.gameObject.SetActive(true);
            OneAnswer4.gameObject.SetActive(true);
        }
        if (collision.CompareTag("TwoQuiz"))
        {
            PanelImage2.gameObject.SetActive(true);
            PanelImage2_1.gameObject.SetActive(true);
            SubQuiz1.gameObject.SetActive(true);
            SubQuiz2.gameObject.SetActive(true);
            SubQuiz3.gameObject.SetActive(true);
            SubQuiz4.gameObject.SetActive(true);
            SubQuiz5.gameObject.SetActive(true);
            SubQuiz6.gameObject.SetActive(true);
            QuizText2.gameObject.SetActive(true);
            Answer2_1.gameObject.SetActive(true);
            Answer2_2.gameObject.SetActive(true);
            Answer2_3.gameObject.SetActive(true);
            EX1.gameObject.SetActive(true);
            EX2.gameObject.SetActive(true);
            EX3.gameObject.SetActive(true);
            EX4.gameObject.SetActive(true);
            EX5.gameObject.SetActive(true);
            EX6.gameObject.SetActive(true);
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("hint"))
        {
            speech_bubble.gameObject.SetActive(false);
            speech_bubble_text.gameObject.SetActive(false);
            PlantPicture.gameObject.SetActive(false);
            PlayerPicture.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Quiz"))
        {
            QuizImage1.gameObject.SetActive(false);
            QuizText1.gameObject.SetActive(false);
            PanelImage1.gameObject.SetActive(false);

            OneAnswer1.gameObject.SetActive(false);
            OneAnswer2.gameObject.SetActive(false);
            OneAnswer3.gameObject.SetActive(false);
            OneAnswer4.gameObject.SetActive(false);

            
        }

        if (collision.CompareTag("TwoQuiz"))
        {

            PanelImage2.gameObject.SetActive(false);
            PanelImage2_1.gameObject.SetActive(false);
            SubQuiz1.gameObject.SetActive(false);
            SubQuiz2.gameObject.SetActive(false);
            SubQuiz3.gameObject.SetActive(false);
            SubQuiz4.gameObject.SetActive(false);
            SubQuiz5.gameObject.SetActive(false);
            SubQuiz6.gameObject.SetActive(false);
            QuizText2.gameObject.SetActive(false);
            Answer2_1.gameObject.SetActive(false);
            Answer2_2.gameObject.SetActive(false);
            Answer2_3.gameObject.SetActive(false);
            EX1.gameObject.SetActive(false);
            EX2.gameObject.SetActive(false);
            EX3.gameObject.SetActive(false);
            EX4.gameObject.SetActive(false);
            EX5.gameObject.SetActive(false);
            EX6.gameObject.SetActive(false);


        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
