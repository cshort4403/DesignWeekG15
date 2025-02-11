using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{   //create a float to track amount of time left
    public float timeLeft= 3.0f;
    public bool timeIsRunning = true;
    public TextMeshPro Timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   //set timer to true on setup
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {   //if the timer is on and is greater than 0 subtract 1s
        {
            if (timeIsRunning)
            {
                if (timeLeft < 0)
                {
                    timeLeft -= Time.deltaTime;
                    UpdateTimer(timeLeft);
                }
                else
                {   //display text "Time Up" on console
                    Debug.Log("Time Up");
                    timeLeft = 0;
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
        Timer.text = string.Format("{00:00}:{1:00}", mins, secs);

        
    }
}
