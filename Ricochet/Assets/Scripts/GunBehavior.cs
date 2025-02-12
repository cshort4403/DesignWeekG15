using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
	[SerializeField]
	float MaxFireDistance = 10f;

	[SerializeField]
	bool HasShot = false;

	[SerializeField]
	GameObject bullet;

	[SerializeField]
	AudioClip[] ShootClips;

	[SerializeField]
	AudioClip ShellDropClip;

	float ShellDropDelay = 0.5f;
	float TimeSinceShot = 0;

	bool hasPLayedShellDrop = false;

	Vector2 RotateVector = Vector2.zero;
	Vector2 PrevRotate = Vector2.zero;

	private void Awake()
	{
		
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Rotate();

		if(TimeSinceShot >= ShellDropDelay && !hasPLayedShellDrop)
		{
			AudioSource.PlayClipAtPoint(ShellDropClip, transform.position);
			TimeSinceShot = 0;
			hasPLayedShellDrop= true;
		}
		else if(HasShot && !hasPLayedShellDrop)
		{
			TimeSinceShot += Time.deltaTime;
		}

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
		if (shooting && !HasShot)
		{
			
			GameObject b = Instantiate(bullet, transform.position, transform.rotation);
			b.GetComponent<BulletBehavior>().SetMoveDirection(PrevRotate);
			b.GetComponent<BulletBehavior>().pIndex = GetComponentInParent<MovePlayer>().GetPlayerIndex();
			HasShot = true;
			AudioSource.PlayClipAtPoint(ShootClips[0], transform.position);
			hasPLayedShellDrop = false;
		}
		
	}
}


