using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PlayerState
{ 
    DEFAULT = 0,
    HAS_WEAPON = 1,
    HAS_SHIELD = 2,
    HAS_WEAPON_AND_SHIELD = 3
}

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState CurState { get; private set; }

	[SerializeField] Dictionary<PlayerState, List<Sprite>> SpritesForPlayerStates;

	[SerializeField] float framesPerSecond = 30;

    bool StateChanged = false;

	float timeSinceLastFrame = 0;
	int CurFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (StateChanged)
		{
			CurFrame=0;
			ChangeImage();
		}
		AnimatePlayer();
    }
	public void ChangeState(PlayerState state)
    {
        CurState = state;
    }
    private void ChangeImage(int index = 0)
    {
		if (SpritesForPlayerStates[CurState][index] == null) return;

        GetComponentInChildren<SpriteRenderer>().sprite = SpritesForPlayerStates[CurState][index];
    }

   private void AnimatePlayer()
	{
		if(timeSinceLastFrame >= 1/framesPerSecond)
		{
			if(CurFrame < SpritesForPlayerStates[CurState].Count)
			{
				CurFrame++;
			}
			else 
			{
				CurFrame = 0;
			}
			ChangeImage(CurFrame);
		}
		else { timeSinceLastFrame += Time.deltaTime; }
	}



    public void PickUpWeapon()
    {
		switch (CurState)
		{
			case PlayerState.DEFAULT:
                ChangeState(PlayerState.HAS_WEAPON);
                StateChanged = true;
				break;
			case PlayerState.HAS_SHIELD:
				ChangeState(PlayerState.HAS_WEAPON_AND_SHIELD);
				StateChanged = true;
				break;
			default:
				break;
		}
    }
	public void DropWeapon()
	{
		switch (CurState)
		{
			case PlayerState.HAS_WEAPON:
				ChangeState(PlayerState.DEFAULT);
				StateChanged = true;
				break;
			case PlayerState.HAS_WEAPON_AND_SHIELD:
				ChangeState(PlayerState.HAS_SHIELD);
				StateChanged = true;
				break;
			default:
				break;
		}
	}
	public void PickUpArmour()
	{
		switch (CurState)
		{
			case PlayerState.DEFAULT:
				ChangeState(PlayerState.HAS_SHIELD);
				StateChanged = true;
				break;
			case PlayerState.HAS_WEAPON:
				ChangeState(PlayerState.HAS_WEAPON_AND_SHIELD);
				StateChanged = true;
				break;
			default:
				break;
		}
	}
	public void LoseArmor()
	{
		switch (CurState)
		{
			case PlayerState.HAS_SHIELD:
				ChangeState(PlayerState.DEFAULT);
				StateChanged = true;
				break;
			case PlayerState.HAS_WEAPON_AND_SHIELD:
				ChangeState(PlayerState.HAS_WEAPON);
				StateChanged = true;
				break;
			default:
				break;
		}
	}



}
