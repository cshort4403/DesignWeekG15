using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerStateManager : MonoBehaviour
{

	public bool HasWeapon = false;
	public bool HasShield = false;

	GunBehavior GunBehavior;
	Animator controller;

    // Start is called before the first frame update
    void Start()
    {
		GunBehavior = GetComponentInChildren<GunBehavior>();
        controller = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		AnimatePlayer();

		if(HasWeapon && GunBehavior.HasShot)
		{
			DropWeapon();
		}
    }


	private void AnimatePlayer()
	{
		controller.SetBool("HasGun", HasWeapon);
		controller.SetFloat("MoveSpeed", GetComponent<MovePlayer>().MoveDirection.magnitude);
	}



	public void PickUpWeapon()
    {
        if (!HasWeapon)
        {
            HasWeapon = true;
			GunBehavior.HasShot = false;
        }
        
    }
	public void DropWeapon()
	{
		if (HasWeapon)
		{
			HasWeapon = false;
		}
	}
	public void PickUpArmour()
	{
		if(!HasShield)
		{
			HasShield = true;
		}
	}
	public void LoseArmor()
	{
		if (HasShield)
		{
			HasShield = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("GunPickup"))
        {
			PickUpWeapon();
			Destroy(other.gameObject);
        }
		if (other.gameObject.CompareTag("ShieldPickup"))
		{
			PickUpArmour();
			Destroy(other.gameObject);
		}
	}

}
