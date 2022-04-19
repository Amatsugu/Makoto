using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ProjectileData
{
	public float Damage { get; set; }
	public DamageType DamageType { get; set; }
	public bool IsCrit { get; set; }
	public bool IsProc { get; set; }
}

public enum DamageType
{
	None,
	Fire,
	Ice,
	Electric
}
