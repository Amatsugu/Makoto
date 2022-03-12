using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : ScriptableObject
{


	public string DisplayName { get; set; }
	public string Description { get; set; }
	public float BaseFireRate { get; set; }
	public float BaseProjectileFlightSpeed { get; set; }
	public int BaseMultiShot { get; set; }
	public float BaseSpread { get; set; }
	public float BaseRecoil { get; set; }
	public Transform BaseProjectile { get; set; }


	public void HandleInput(InputAction.CallbackContext context, Vector3 spawnPoint, Vector3 forward)
	{ 

	}

	public void FireBurst(Vector3 position, Vector3 forward)
	{
		for (int i = 0; i < BaseMultiShot; i++)
		{
			var proj = InstantiateProjectile(position, forward);
			ApplyProjectileProperties(proj);
		}
	}



	public GameObject InstantiateProjectile(Vector3 position, Vector3 fwd)
	{
		throw new NotImplementedException();
	}

	public void ApplyProjectileProperties(GameObject projectile)
	{

	}
}
