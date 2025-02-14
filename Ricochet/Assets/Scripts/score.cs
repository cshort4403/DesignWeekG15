using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{   //create variable to keep count of score
    public int scoreCount = 0;
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
        //add increment to score
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //AddScore(1);

        //}


    }
    /*
        private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        AddScore();
    }*/
    public void AddScore(int amount)
    {   //add increment to score
        scoreCount += amount;
        //update score
        UpdateScoreDisplay();

    }
    //create function to display updated score
    void UpdateScoreDisplay()
    {   //display updated score
        scoreText.text = scoreCount.ToString();

    }
}

