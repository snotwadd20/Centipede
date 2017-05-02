using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushrooms : MonoBehaviour 
{
	public int numMushrooms = 20;

	public Mushroom mushroomPrefab = null;

	public float top = 0;
	public float bottom = 0;
	public float left = 0;
	public float right = 0;
	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < numMushrooms; i++)
		{
			Spawn();
		}//for
	}//Awake

	void Spawn()
	{
		Mushroom mushroom = Instantiate<Mushroom>(mushroomPrefab);
		mushroom.gameObject.SetActive(true);
		Vector2 pos = new Vector2(Random.Range(left, right), Random.Range(bottom, top));
		mushroom.transform.position = pos;
	}//Spawn
	
	// Update is called once per frame
	void Update () 
	{
		
	}//Update

	void OnDrawGizmos()
	{
		Vector2 topRight = new Vector2(right, top);
		Vector2 topLeft = new Vector2(left, top);
		Vector2 bottomRight = new Vector2(right, bottom);
		Vector2 bottomLeft = new Vector2(left, bottom);

		Gizmos.color = Color.red;

		Gizmos.DrawLine(topRight, bottomRight);

		Gizmos.color = Color.green;

		Gizmos.DrawLine(bottomRight, bottomLeft);

		Gizmos.color = Color.blue;

		Gizmos.DrawLine(bottomLeft, topLeft);

		Gizmos.color = Color.yellow;

		Gizmos.DrawLine(topLeft, topRight);

	}//OnDrawGizmos
}//
