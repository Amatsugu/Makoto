using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float turnSpeed;

	private PlayerInput _input;
	private CharacterController _characterController;
	private Vector2 _vel;

	// Start is called before the first frame update
	void Start()
	{
		_input = GetComponent<PlayerInput>();
		_characterController = GetComponent<CharacterController>();
		_vel = Vector3.zero;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

#if DEBUG
	private void OnValidate()
	{
		if(Application.isEditor && Application.isPlaying)
		{
			Start();
		}
	}
#endif
	// Update is called once per frame
	void Update()
	{
		_characterController.Move(_vel * Time.deltaTime);
	}

	public void Move(InputAction.CallbackContext context)
	{
		switch (context.phase)
		{
			case InputActionPhase.Disabled:
				break;
			case InputActionPhase.Waiting:
				break;
			case InputActionPhase.Started:
				break;
			case InputActionPhase.Performed:
				var pos = context.ReadValue<Vector2>();
				_vel = pos * moveSpeed;
				break;
			case InputActionPhase.Canceled:
				_vel = Vector2.zero;
				break;
		}
	}

	public void Dash(InputAction.CallbackContext context)
	{

	}

	public void Aim(InputAction.CallbackContext context)
	{
		var pos = context.ReadValue<Vector2>();
		Debug.Log($"Aim: {pos}");
	}

	public void MousePos(InputAction.CallbackContext context)
	{
		var pos = context.ReadValue<Vector2>();
		//Debug.Log($"Pos: {pos}");
	}
}

