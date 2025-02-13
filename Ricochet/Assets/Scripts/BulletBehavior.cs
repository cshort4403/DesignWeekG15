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

    float aliveTime = 0;

    public int pIndex = 0;

    bool IsColliding = false;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = transform.right * speed;
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
			aliveTime += Time.deltaTime;
        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (!IsColliding)
        {
			if (collision.gameObject.CompareTag("Wall") && numBounces > 0)
            {
				transform.right = Vector3.Reflect(transform.right, collision.contacts[0].normal);
				rb2d.velocity = transform.right * speed;
				// transform.Rotate(newRot);
				IsColliding = true;
				numBounces--;
                Debug.Log($"Wall collision {rb2d.velocity}");
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
