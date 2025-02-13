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

	Vector2 RotateVector = Vector2.zero;
	Vector2 PrevRotate = Vector2.zero;

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
		Rotate();
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
	public void SetRotateVector(Vector2 direction)
	{
		RotateVector = direction;
	}
	private void Rotate()
	{
		if (RotateVector != Vector2.zero)
		{
			PrevRotate = RotateVector;
		}

		float angle = Mathf.Atan2(PrevRotate.y, PrevRotate.x) * Mathf.Rad2Deg + 90;
		transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
	}

	public void ResetPosition()
	{
		transform.SetPositionAndRotation(StartPosition, Quaternion.AngleAxis(StartRotation, Vector3.forward));
	}
}
