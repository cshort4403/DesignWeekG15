using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class score1 : MonoBehaviour
{   //create variable to keep count of score
    public int scoreCount = 0;
    //refrence text
    public Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the score display
        UpdateScoreDisplay();

    }

    // Update is called once per frame
    void Update()
    {
        //increase score if space button is pressed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            AddScore(1);
        }

    }/*
    private void OnTriggerEnter2D(Collider2D collision)
    {   //if game object is destroyed add 1 to score
        Destroy(collision.gameObject);
        AddScore(1);
    }
    */

    void AddScore(int amount)
    {   //add increment to score
        scoreCount += amount;
        //call function
        UpdateScoreDisplay();
    }
    //create function to display updated score
    private void UpdateScoreDisplay()
    {
        //display updated score
        scoreText.text = scoreCount.ToString();
    }
}

