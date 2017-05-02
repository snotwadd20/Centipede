using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour 
{
	public Sprite[] damageStates = null;

	private SpriteRenderer spriteRenderer = null;
	public int currentDamageState = 0;

	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = damageStates[0];
	}//Awake

	void Damage(int amount)
	{
		currentDamageState++;
	}//Damage
	
	void Update () 
	{
		if (currentDamageState < damageStates.Length)
		{
			spriteRenderer.sprite = damageStates[currentDamageState];
		}//if
		else
		{
			Destroy(gameObject);
		}//else
	}//Update

}//Mushroom
