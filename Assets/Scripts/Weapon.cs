using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	protected uint damage;

	public abstract void Fire ();
}

