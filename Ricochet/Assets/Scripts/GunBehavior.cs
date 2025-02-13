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

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
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
	
	
	public void Shoot(bool shooting)
	{
		if (shooting && !HasShot)
		{
			float angle = transform.parent.rotation.eulerAngles.z;

			GameObject b = Instantiate(bullet, transform.position, transform.parent.rotation);
			b.GetComponent<BulletBehavior>().SetMoveDirection(new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)));
			b.GetComponent<BulletBehavior>().pIndex = GetComponentInParent<MovePlayer>().GetPlayerIndex();
			HasShot = true;
			AudioSource.PlayClipAtPoint(ShootClips[0], transform.position);
			hasPLayedShellDrop = false;
		}
		
	}
}


