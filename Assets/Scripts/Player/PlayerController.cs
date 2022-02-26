using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private PlayerInput _input;
	// Start is called before the first frame update
	void Start()
	{
		_input = GetComponent<PlayerInput>();
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
		
	}

	public void Move(InputAction.CallbackContext context)
	{
		var pos = context.ReadValue<Vector2>();
		Debug.Log($"Move: {pos}");
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

