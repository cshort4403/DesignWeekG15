using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    float speed =10f;
    [SerializeField]
    int numBounces = 5;
    [SerializeField]
    float maxAliveTime = 2;

    Vector2 MoveDirection;
    Rigidbody2D rb2D;

    float aliveTime = 0;

    public int pIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aliveTime >= maxAliveTime)
        {
            Destroy(gameObject);
        }
        else
        {
            rb2D.velocity = speed * Time.deltaTime * MoveDirection;
            aliveTime += Time.deltaTime;
        }
    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        MoveDirection = moveDir;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Wall") && numBounces > 0) 
        {
            SetMoveDirection(Vector3.Reflect(MoveDirection, collision.GetContact(0).normal));
            numBounces--;
        }
        else if (numBounces <= 0)
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() != pIndex)
        {
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            {
                g.GetComponent<MovePlayer>().ResetPosition();
                Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");
            }
            //Change Score

			Destroy(gameObject);
        }


	}

}
