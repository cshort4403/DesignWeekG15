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

	public GameObject MuzzleFlash;

	float flashTimeLapse = 0;
	float maxFlashTime = 1f;
	public bool flashing = false;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(TimeSinceShot >= ShellDropDelay && !hasPLayedShellDrop)
		{
			Debug.Log("Shell Drop");
			AudioSource.PlayClipAtPoint(ShellDropClip, transform.position);
			TimeSinceShot = 0;
			hasPLayedShellDrop = true;

        }
		else if(HasShot && !hasPLayedShellDrop)
		{
			TimeSinceShot += Time.deltaTime;
		}

		if(flashing = true && flashTimeLapse <= maxFlashTime)
		{
			flashTimeLapse += Time.deltaTime;
        }
		else if (flashing = true && flashTimeLapse >= maxFlashTime)
		{
            MuzzleFlash.SetActive(false);
			flashing = false;
			flashTimeLapse = 0f;
        }

    }
	
	
	public void Shoot(bool shooting)
	{
		if (shooting && !HasShot)
		{
			float angle = transform.parent.rotation.eulerAngles.z;

			GameObject b = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,angle - 90));
			b.GetComponent<BulletBehavior>().pIndex = GetComponentInParent<MovePlayer>().GetPlayerIndex();
			//HasShot = true;
			AudioSource.PlayClipAtPoint(ShootClips[0], transform.position);
			hasPLayedShellDrop = false;

            MuzzleFlash.SetActive(true);
            flashing = true;

            Debug.Log($"Shot at {angle}");
		}
		
	}
}


