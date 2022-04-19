using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
	public Weapon weapon;
	public Transform _projectileSpawn;


	private Transform _transform;
	private PlayerController _controller;

	private bool _isFiring;
	private float _nextFireTime;


    void Start()
    {
        _transform = transform;
		_controller = GetComponent<PlayerController>();	
    }

	private void FixedUpdate()
	{
		if (_isFiring && _nextFireTime <= Time.time)
		{
			weapon.FireProjectile(_projectileSpawn.position, _controller.CurLook);
			_nextFireTime = Time.time + (1f / weapon.baseFireRate);
			_controller.ApplyRecoil(weapon.baseRecoil);
		}
	}

	public void HandleInput(InputAction.CallbackContext context)
	{
		switch (context.phase)
		{
			case InputActionPhase.Disabled:
				break;
			case InputActionPhase.Waiting:

				break;
			case InputActionPhase.Started:
				_isFiring = true;
				break;
			case InputActionPhase.Performed:
				_isFiring = true;
				break;
			case InputActionPhase.Canceled:
				_isFiring = false;
				break;
		}
	}

}
