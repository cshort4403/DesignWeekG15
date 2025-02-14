using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    //The max time the explosion will exist
    [SerializeField]
    float blastMaxAliveTime = 5f;

    //How long the blast has existed
    float blastAliveTime = 0f;

    //The physical existance of the explosion
    Rigidbody2D rb2D;

    public int pIndex = 3;

    //If it is touching the player or not.
    bool IsColliding = false;

    //What the sound is that plays when the barrel explodes
    [SerializeField]
    AudioClip Detonation;

    float blastWaveDelay = 0.5f;

    [SerializeField]
    bool HasKaboomed = false;

    float TimeSinceBoom = 0f;

    bool hasPLayedTheBoom = false;

    //public score score;
    //public score1 score1;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        //
        //pIndex = 3;
    }

    private void Awake()
    {
        AudioSource.PlayClipAtPoint(Detonation, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //if (TimeSinceBoom >= blastWaveDelay && !hasPLayedTheBoom)
        //{
            //Debug.Log("Play sound");
            //AudioSource.PlayClipAtPoint(Detonation, transform.position);
            ////TimeSinceShot = 0;
            //hasPLayedTheBoom = true;
        //}
        //else if (HasKaboomed && !hasPLayedTheBoom)
        //{
            //TimeSinceBoom += Time.deltaTime;
        //}

        if (blastAliveTime >= blastMaxAliveTime)
        {
            Destroy(gameObject);
        }
        else
        {
            blastAliveTime += Time.deltaTime;
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (!IsColliding)
        //{
            //if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() == 0)
            //{

                //IsColliding = true;
                //foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
                //{
                    //g.GetComponent<MovePlayer>().ResetPosition();
                    //Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");

                    //score1.AddScore(1);
                //}
            //}

            //if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() == 1)
            //{

                //IsColliding = true;
                //foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
                //{
                    //g.GetComponent<MovePlayer>().ResetPosition();
                    //Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");

                    //score.AddScore(1);
                //}
            //}
        //}
    //}
}
