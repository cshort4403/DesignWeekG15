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

	AudioSource AudioSource;

	[SerializeField]
	AudioClip[] audioClips;

	public score score;
	public score1 score1;

    // Start is called before the first frame update
    void Start()
    {
		GunBehavior = GetComponentInChildren<GunBehavior>();
        controller = GetComponentInChildren<Animator>();
		AudioSource = GetComponent<AudioSource>();
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

	public void ResetPlayer()
	{
		HasWeapon = false;
		HasShield = false;
		GunBehavior.HasShot = false;
		AnimatePlayer();
	}

	private void AnimatePlayer()
	{
		controller.SetBool("HasGun", HasWeapon);
		controller.SetBool("HasShield", HasShield);
		controller.SetFloat("MoveSpeed", GetComponent<MovePlayer>().MoveDirection.magnitude);
	}



	public void PickUpWeapon(GameObject weapon)
    {
        if (!HasWeapon)
        {
            HasWeapon = true;
			GunBehavior.HasShot = false;
			AudioSource.PlayOneShot(audioClips[0], 0.5f);
			Destroy(weapon);
		}
        
    }
	public void DropWeapon()
	{
		if (HasWeapon)
		{
			AudioSource.PlayOneShot(audioClips[1], 0.5f);
			HasWeapon = false;
		}
	}
	public void PickUpArmour(GameObject shield)
	{
		if(!HasShield)
		{
			HasShield = true;
			AudioSource.PlayOneShot(audioClips[2]);
			Destroy(shield);
		}
	}
	public void LoseArmor()
	{
		if (HasShield)
		{
			HasShield = false;
		}
	}

	public void DoDyingAnim()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("GunPickup"))
        {
			PickUpWeapon(other.gameObject);
        }
		if (other.gameObject.CompareTag("ShieldPickup"))
		{
			PickUpArmour(other.gameObject);
			
		}
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			if (collision.gameObject.GetComponent<BulletBehavior>().pIndex != GetComponent<MovePlayer>().GetPlayerIndex())
			{
				if (HasShield)
				{
					//Get rid of the player's armor
					LoseArmor();
					//Make the bullet belong to the player so it can bounce back and hit the other player?
					collision.gameObject.GetComponent<BulletBehavior>().pIndex = GetComponent<MovePlayer>().GetPlayerIndex();
					//Bounce the bullet?
					collision.gameObject.GetComponent<BulletBehavior>().Bounce(collision.GetContact(0).normal);
				}
				else
				{
					AudioSource.PlayOneShot(audioClips[4]);
					
					//Change Score for other player
					if (collision.gameObject.GetComponent<BulletBehavior>().pIndex == 0)
					{
						score.AddScore(1);
					}
					else if (collision.gameObject.GetComponent<BulletBehavior>().pIndex == 1)
					{
						score1.AddScore(1);
					}
					GameManager.Instance.ResetLevel();
				}
			}
		}

		if (collision.gameObject.CompareTag("Blast"))
		{
			if (GetComponent<MovePlayer>().GetPlayerIndex() == 0)
			{
                if (HasShield)
                {
                    LoseArmor();
                    //collision.gameObject.GetComponent<BulletBehavior>().pIndex = GetComponent<MovePlayer>().GetPlayerIndex();
                    //collision.gameObject.GetComponent<BulletBehavior>().Bounce(collision.GetContact(0).normal);
                }
                else
                {
                   
                    score1.AddScore(1);
					GameManager.Instance.ResetLevel();
                }
            }
			else if (GetComponent<MovePlayer>().GetPlayerIndex() == 1)
			{
                if (HasShield)
                {
                    LoseArmor();
                    //collision.gameObject.GetComponent<BulletBehavior>().pIndex = GetComponent<MovePlayer>().GetPlayerIndex();
                    //collision.gameObject.GetComponent<BulletBehavior>().Bounce(collision.GetContact(0).normal);
                }
                else
                {
                    score.AddScore(1);
					GameManager.Instance.ResetLevel();
                }
            }

        }
    }
}
