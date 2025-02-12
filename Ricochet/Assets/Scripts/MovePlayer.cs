using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	Vector2 InputVector = Vector2.zero;
	Vector2 MoveDirection = Vector2.zero;


	[SerializeField]
	float MoveSpeed = 5;

	[SerializeField]
	private int PlayerIndex = 0;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	

	public void SetInputVector(Vector2 direction)
	{
		InputVector = direction;
	}



	public int GetPlayerIndex()
	{
		return PlayerIndex;
	}

	private void Move()
	{
		MoveDirection = new Vector2(InputVector.x, InputVector.y);
		MoveDirection = transform.TransformDirection(MoveDirection);
		MoveDirection *= MoveSpeed;

		transform.Translate(MoveDirection * Time.deltaTime);
	}
}
