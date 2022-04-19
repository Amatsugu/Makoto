using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : ScriptableObject
{


	public string displayName;
	public string description;
	public float baseFireRate;
	public float accuracy;
	public float baseProjectileFlightSpeed;
	public int baseMultiShot;
	public float baseSpread;
	public float baseRecoil;
	public GameObject baseProjectile;


	public void FireProjectile(Vector3 position, Vector3 forward)
	{
		for (int i = 0; i < (baseMultiShot + 1); i++)
		{
			var proj = InstantiateProjectile(position, forward);
			ApplyProjectileProperties(proj);
		}
	}



	public GameObject InstantiateProjectile(Vector3 position, Vector3 fwd)
	{
		return Instantiate(baseProjectile, position, Quaternion.LookRotation(Vector3.forward, fwd));
	}

	public void ApplyProjectileProperties(GameObject projectile)
	{
		var rb = projectile.GetComponent<Rigidbody2D>();
		var transform = projectile.transform;
		rb.velocity = transform.up * baseProjectileFlightSpeed;


	}
}
