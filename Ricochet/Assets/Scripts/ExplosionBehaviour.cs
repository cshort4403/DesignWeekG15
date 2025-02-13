using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField]
    float blastMaxAliveTime = 5f;

    float blastAliveTime = 0f;

    Rigidbody2D rb2D;

    public int bPIndex = 0;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (blastAliveTime >= blastMaxAliveTime)
        {
            Destroy(gameObject);
        }
        else
        {
            blastAliveTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() != bPIndex)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            {
                g.GetComponent<MovePlayer>().ResetPosition();
                Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");
            }
        }
    }
}
