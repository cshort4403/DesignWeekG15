using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{   //create a float to track amount of time left
    public float timeLeft = 5f;
    public bool timeIsRunning = true;
    public Text CountdownTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   //set timer to true on setup
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {   //if the timer is on and is greater than 0 subtract 1
        {
            if (timeIsRunning)
            {
                if (timeLeft > 0)
                {  
                    UpdateTimer(timeLeft);
                    timeLeft -= Time.deltaTime;
                    
                }
                else
                {   //display text "Time Up" on console
                    Debug.Log("Time Up");
                }

            }
        }
    }
    void UpdateTimer(float timeLeft)
    {
        //increment current time level by 1
        timeLeft -= 1;

        //create variable for minutes and seconds
        //divide currentTime by 60 and convert it into intergers and store inside mins var
        //perform modulo on current time by 60 ,conv into int and store inside var
        float mins = Mathf.FloorToInt(timeLeft / 60);
        float secs = Mathf.FloorToInt(timeLeft % 60);

        //input mins and secs variable in desired format
        CountdownTime.text = string.Format("{00:00}:{01:00}", mins, secs);

        
    }
}
