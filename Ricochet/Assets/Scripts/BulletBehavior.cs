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

    Vector2 MoveDirection = Vector2.zero;

    float aliveTime = 0;

    public int pIndex = 0;

    bool IsColliding = false;
    

    // Start is called before the first frame update
    void Start()
    {
		
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
            Move();
			aliveTime += Time.deltaTime;
        }
    }
    void Move()
    {
        Vector2 newDir = transform.TransformDirection(MoveDirection);
		transform.Translate(newDir * speed * Time.deltaTime);
	}

    public void SetMoveDirection(Vector2 moveDir)
    {
        MoveDirection = moveDir;
     
        Debug.Log($"Set bullet movedirection to {MoveDirection}. Input was {moveDir}");
       
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (!IsColliding)
        {
			if (collision.gameObject.CompareTag("Wall") && numBounces > 0)
            {
                SetMoveDirection(Vector3.Reflect(MoveDirection, collision.GetContact(0).normal));
				IsColliding = true;
				numBounces--;
            }
            else if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() != pIndex)
            {
				IsColliding = true;
				foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
                {
                    g.GetComponent<MovePlayer>().ResetPosition();
                    Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");
                }
                //Change Score

                Destroy(gameObject);
            }
            else if (numBounces <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			IsColliding = false;
		}
		 //Only check collisions once
	}

}
