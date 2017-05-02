using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour 
{
	public Bullet bulletPrefab = null;

	//public float maxY = -2.5f;
	public float moveSpeed = 10.0f;
	public float shotSpeed = 10.0f;

	public BoxCollider2D shipBounds = null;

	private float inputX = 0;
	private float inputY = 0;

	private Rigidbody2D rb2d = null;

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();

	}//Awake

	void Shoot()
	{
		Bullet bullet = Instantiate<Bullet>(bulletPrefab);
		bullet.transform.position = transform.position;
		bullet.gameObject.SetActive(true);
		bullet.Shoot(Vector2.up * shotSpeed);
	}//Shoot

	// Update is called once per frame
	void Update () 
	{
		inputX = Input.GetAxisRaw("Horizontal");
		inputY = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Shoot();
		}//if
	}//Update

	void FixedUpdate()
	{
		//Vector2 oldPos = (Vector2)transform.position;

		float xVel = inputX * moveSpeed * Time.deltaTime;
		float yVel = inputY * moveSpeed * Time.deltaTime;
		Vector2 moveVec = new Vector2(xVel, yVel);

		if (shipBounds.bounds.Contains((Vector2)transform.position + moveVec))
		{
			//transform.Translate(moveVec);
			rb2d.MovePosition((Vector2)transform.position + moveVec);
		}//if


	}//FixedUpdate
}//Ship
