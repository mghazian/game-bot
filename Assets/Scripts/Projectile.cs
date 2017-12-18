using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damage { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log ("PROJECTILE COLLIDED");
		if (other.gameObject.tag == "Player")
			other.gameObject.GetComponent<Character>().UpdateHealth (-damage);
		Destroy (gameObject);
	}
}
