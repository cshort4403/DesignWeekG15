using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
	[SerializeField]
	float MaxFireDistance = 10f;

	[SerializeField]
	bool HasShot = false;

	LineRenderer _LineRenderer;
	Vector2 RotateVector = Vector2.zero;
	Vector2 PrevRotate = Vector2.zero;

	private void Awake()
	{
		_LineRenderer = GetComponent<LineRenderer>();
	}

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
			PrevRotate = RotateVector;
			float angle = Mathf.Atan2(RotateVector.y, RotateVector.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	public void Shoot(bool shooting)
	{
		if(shooting) 
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, PrevRotate, MaxFireDistance);
			_LineRenderer.enabled = true;
			_LineRenderer.SetPosition(0, transform.position);

			if (hit)
			{
				_LineRenderer.SetPosition(1, hit.point);
				
				Debug.Log($"Shot hit {hit.point}");
			}
			else
			{
				_LineRenderer.SetPosition(1, MaxFireDistance * PrevRotate);
			}
		}

	}
}
