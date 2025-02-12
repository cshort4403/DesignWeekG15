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

	Vector3 StartPosition = Vector3.zero;
	float StartRotation = 0f;

	// Start is called before the first frame update
	void Start()
    {
        StartPosition = transform.position;
		StartRotation = transform.rotation.eulerAngles.z;
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

	public void ResetPosition()
	{
		transform.SetPositionAndRotation(StartPosition, Quaternion.AngleAxis(StartRotation, Vector3.forward));
	}
}
