using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{   //create variable to keep count of score
    public int scoreCount = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = scoreCount.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {   //increase score if space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreCount++;
            AddScore(1);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   //if game object is destroyed add 1 to score
        Destroy(collision.gameObject);
        AddScore(1);
    }

    void AddScore(int amount)
    {   //add increment to score
        scoreCount += amount;
        //update score
        scoreText.text = scoreCount.ToString();
        }
    }

