using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{   //create variable to keep count of score
    public int scoreCount = 0;
    public Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        AddScore();
    }
    void AddScore()
    {   //add increment to score
        scoreCount++;
        scoreText.text = scoreCount.ToString();
    }
}
