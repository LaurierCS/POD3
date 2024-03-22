using System;
using System.Collections;
using System.Dynamic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsManager : MonoBehaviour
{
    public Text questionText;
    public Text scoreText;
    public Text FinalScore;
    public Button[] replyButtons;
    public Qtsdata qtsData;
    public GameObject Right;
    public GameObject Wrong;
    public GameObject GameFinished;

    private int currentQuestion = 0;
    private static int score = 0;

    private void Start()
    {
        SetQuestion(currentQuestion);
        Right.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);
    }

    void SetQuestion(int questionIndex)
    {
        questionText.text = qtsData.questions[questionIndex].questionsText;

        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<Text>().text = qtsData.questions[questionIndex].replies[i];
            int replyIndex = i;
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReply(replyIndex);
            });
        }
    }

    void CheckReply(int replyIndex)
    {
        if (replyIndex == qtsData.questions[currentQuestion].correctReplyIndex)
        {
            score++;
            scoreText.text = "" + score;

            Right.gameObject.SetActive(true);
            foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());
        }
        else
        {
            Wrong.gameObject.SetActive(true);
            foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());

        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        currentQuestion++;
        if (currentQuestion < qtsData.questions.Length)
        {
            Reset();
        }
        else
        {
            GameFinished.SetActive(true);
            float scorePercentage = (float)score / qtsData.questions.Length * 100;
            FinalScore.text = "You scored " + scorePercentage.ToString("F0") + "%";

            if (scorePercentage < 50)
            {
                FinalScore.text += "\nGame Over";
            }
            else if (scorePercentage < 60)
            {
                FinalScore.text += "\nKeep Trying";
            }
            else if (scorePercentage < 70)
            {
                FinalScore.text += "\nGood Job";
            }
            else if (scorePercentage < 80)
            {
                FinalScore.text += "\nWell Done";
            }
            else
            {
                FinalScore.text += "\nYou're a genius!";
            }
        }

    }

    public void Reset()
    {

        Right.SetActive(false);
        Wrong.SetActive(false);

        foreach (Button r in replyButtons)
        {
            r.interactable = true;
        }

        SetQuestion(currentQuestion);

    }
}






