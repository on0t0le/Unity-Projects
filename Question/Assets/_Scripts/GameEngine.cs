using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameEngine : MonoBehaviour {

    public Question[] questions;
    public GameObject endScreen;

    private static List<Question> unansweredQestions;
    private Question currentQuestion;
    private int score;

    [SerializeField]
    private int remainQuestions;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text scoreField;
    [SerializeField]
    private Text endScoreField;

    void Start () {

        if(unansweredQestions == null || unansweredQestions.Count == 0)
        {
            unansweredQestions = questions.ToList<Question>();
        }
        
        remainQuestions = unansweredQestions.Count;

        GetNextQuestion();
        //Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
       // questionText.text = currentQuestion.fact;
        	
	}

    void Update()
    {
        questionText.text = currentQuestion.fact;
        scoreField.text = score.ToString();
        endScoreField.text = score.ToString();

    }
    

    void GetNextQuestion()
    {
        if (unansweredQestions.Count == 0)
        {
            //Application.Quit();
            //return;
            if (!endScreen.GetComponent<Animator>().enabled)
                endScreen.GetComponent<Animator>().enabled = true;
            else
            {
                
                endScreen.GetComponent<Animator>().SetTrigger("End");

            }
               
        }
        else
        {

        int questionIndex = Random.Range(0, unansweredQestions.Count);
        currentQuestion = unansweredQestions[questionIndex];

        unansweredQestions.Remove(currentQuestion);
        }

    }

    public void isTrueAnswer()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            score++;

        }else
        {
            Debug.Log("Wrong!");
        }
        GetNextQuestion();
    }

    public void isFalseAnswer()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            score++;
        }
        else
        {
            Debug.Log("Wrong!");
        }
        GetNextQuestion();
    }

    public void RestartGame()
    {
        Application.LoadLevel("Main");
    }
    public void EndGame()
    {
        Application.LoadLevel("MainMenu");
    }
}
