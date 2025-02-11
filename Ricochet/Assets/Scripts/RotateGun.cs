using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{

	Vector2 RotateVector = Vector2.zero;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
	public void SetRotateVector(Vector2 direction)
	{
		RotateVector = direction;
	}
	private void Rotate()
	{
		if (RotateVector != Vector2.zero)
		{
			float angle = Mathf.Atan2(RotateVector.y, RotateVector.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
