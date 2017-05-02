using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour 
{
	
	// Use this for initialization
	void Awake () 
	{
		
	}//Awake
	
	// Update is called once per frame
	void Update () 
	{
		
		
		//Move in a direction
		//When you hit a collider, move down one length then move in the other direction
		//Update tail
	}//Update

	void UpdateTail()
	{
		//Iterate through tail and have each segment go to the position the previous segment was in
	}//UpdateTail

	void SplitPede()
	{
		//Turn the piece hit into a mushroom
		//Turn the piece behind it into a head, and attach all other peices behind it as tails
	}//
}//
