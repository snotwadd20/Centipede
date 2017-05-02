﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public float maxDist = 20.0f;
	private Vector2 startSpot = Vector2.zero;
	private Rigidbody2D rb2d = null;
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}//

	public void Shoot(Vector3 shotVelocity)
	{
		shotVelocity.z = 0;
		startSpot = transform.position;
		rb2d.velocity = shotVelocity;
		//Vector3 lookat = transform.position + shotVelocity;
		//lookat.z = 0;
		//transform.up = lookat - transform.position;
	}//Shoot

	void Update()
	{
		if (Vector2.Distance(startSpot, transform.position) > maxDist)
			Explode();
	}//Update

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<Ship>())
			return;

		coll.gameObject.SendMessage("Damage", 1, SendMessageOptions.DontRequireReceiver);
		Explode();
	}//Collider2D

	void Explode()
	{
		Destroy(gameObject);
	}//
}//
