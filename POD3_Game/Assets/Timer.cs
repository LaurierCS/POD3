using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Update is called once per frame
    void Update()
    {

        if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        else
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        //function (add to timer) to call to add time kill an enemy
        // function (lose to timer) lose time if player get hit
    }


    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;

        timerText.color = Color.red;
    }


    public void LoseTime(float timeToLose)
    {
        remainingTime -= timeToLose;

        if (remainingTime < 0)
        {
            remainingTime = 0;

            timerText.color = Color.red;
        }
    }
}

