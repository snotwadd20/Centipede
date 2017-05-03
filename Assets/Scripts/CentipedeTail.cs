using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeTail : MonoBehaviour 
{
    public CentipedeTail tailAhead = null;
    public CentipedeTail tailBehind = null;
    public Vector2 pos { get { return (Vector2)transform.position; } }
    private Rigidbody2D rb2d = null;

    void Awake () 
	{
        rb2d = GetComponent<Rigidbody2D>();	
	}//Awake

    public void MoveTo(Vector2 pos)
    {
        rb2d.MovePosition(pos);
    }//
	
	void Update () 
	{
    }//Update
}//