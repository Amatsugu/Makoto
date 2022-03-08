using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float dashSpeed;
	public float dashDistance;
	public float turnSpeed;

	public Transform body;

	private PlayerInput _input;
	private Rigidbody2D _rigidbody;
	private Vector2 _vel;
	private Vector2 _dashVel;
	private Vector2 _curLook;
	private float _dashTime;
	private Transform _transform;

	// Start is called before the first frame update
	private void Start()
	{
		_input = GetComponent<PlayerInput>();
		_rigidbody = GetComponent<Rigidbody2D>();	
		_transform = transform;
		_vel = Vector3.zero;
	}

#if DEBUG

	private void OnValidate()
	{
		if (Application.isEditor && Application.isPlaying)
		{
			Start();
		}
	}

#endif

	public void Update()
	{
		body.rotation = Quaternion.LookRotation(Vector3.forward, _curLook);
		Debug.DrawRay(_transform.position, _curLook, Color.magenta);
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		var curVel = _vel;
		if (_dashTime > Time.time)
		{
			curVel = _dashVel * dashSpeed;
			Debug.DrawRay(_transform.position, curVel.normalized * dashDistance, Color.white);
		}	
		_rigidbody.velocity = curVel;
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
		if (context.phase != InputActionPhase.Performed)
			return;
		if (_vel.magnitude == 0)
			return;
		_dashVel = _vel.normalized;
		_dashTime = (dashDistance / dashSpeed) + Time.time;
	}

	public void Aim(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Canceled)
			return;
		var look = context.ReadValue<Vector2>();
		_curLook = look;
		Debug.Log($"Aim: {look}");
	}

	public void MousePos(InputAction.CallbackContext context)
	{
		var pos = context.ReadValue<Vector2>();
		pos = Camera.main.ScreenToWorldPoint(pos);
		_curLook = pos - (Vector2)_transform.position;
		_curLook.Normalize();
		//Debug.Log($"Pos: {pos}");
	}
}