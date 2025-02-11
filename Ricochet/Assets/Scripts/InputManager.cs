using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class InputManager : MonoBehaviour
{
	PlayerInput pInput;
	MovePlayer _MovePlayer;

	private void Awake()
	{
		pInput = GetComponent<PlayerInput>();
		int index = pInput.playerIndex;

		var movers = FindObjectsOfType<MovePlayer>();

		_MovePlayer = movers.FirstOrDefault(m => m.GetPlayerIndex()==index);
		
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMove(CallbackContext context)
    {
		_MovePlayer.SetInputVector(context.ReadValue<Vector2>());
    }

	public void OnRotate(CallbackContext context)
	{
		_MovePlayer.GetComponentInChildren<RotateGun>().SetRotateVector(context.ReadValue<Vector2>());
	}
	public void OnShoot(CallbackContext context)
	{
		
	}



}
