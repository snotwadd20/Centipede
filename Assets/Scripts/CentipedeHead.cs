using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeHead : MonoBehaviour 
{
    public float speed = 10.0f;
    public int tailLength = 10;

    public CentipedeTail tailPrefab = null;
    private CentipedeTail tail = null;

    private Vector2 dir = Vector2.right;

    private Rigidbody2D rb2d = null;
    private Collider2D coll = null;
    private float size = -1;
    private Vector2 lastDir = Vector2.right;

    public Vector2 pos { get { return (Vector2)transform.position; } }

    private float moveDownTimer = 0;
	void Awake () 
	{
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        size = Mathf.Max(coll.bounds.extents.x, coll.bounds.extents.y) * 2;
        SpawnTail();
	}//Awake

    void SpawnTail()
    {
        CentipedeTail tempTail = null;
        //Spawn first tail piece and link it
        tail = Instantiate<CentipedeTail>(tailPrefab, pos + Vector2.left * size, Quaternion.identity);
        tail.gameObject.name = "Tail_" + 0;
        tempTail = tail;

        //Then spawn the rest
        for (int i = 1; i < tailLength; i++)
        {
            CentipedeTail newTail = Instantiate<CentipedeTail>(tailPrefab, pos + Vector2.left * size * (i + 1), Quaternion.identity);
            newTail.gameObject.name = "Tail_" + i;

            //Previous tailpiece needs to know what's behind it
            tempTail.tailBehind = newTail;

            //This new tail piece needs to know what's ahead
            newTail.tailAhead = tempTail;
            tempTail = newTail;
        }//for
    }//SpawnTail

    void Start()
    {
       
    }//Start

	void Update () 
	{
        
        Vector2 moveVec = dir * speed * Time.deltaTime;

        UpdateHead(moveVec);
        print("MOVEVEC: " + moveVec);
        UpdateTail(moveVec);
	}//Update

    void UpdateHead(Vector2 moveVec)
    {
        rb2d.MovePosition(pos + moveVec);

        if (dir == Vector2.down)
        {
            moveDownTimer += Time.deltaTime;
            if (moveDownTimer > 0.1f)
                SwitchDirection();
        }//if
    }//UpdateHead

    void UpdateTail(Vector2 moveVec)
    {
        CentipedeTail pointer = tail;

        while (pointer != null)
        {
            pointer.MoveTo(pointer.pos + moveVec);
            pointer = pointer.tailBehind;
        }//while
    }//UpdateTail

    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.gameObject.SendMessage("Damage",1, SendMessageOptions.DontRequireReceiver);
        SwitchDirection();
    }//Collision2D

    void SwitchDirection()
    {
        if (dir != Vector2.down)
        {
            lastDir = dir;
            dir = Vector2.down;
            moveDownTimer = 0;
            return;
        }//if

        dir = lastDir * -1;
        
    }//SwitchDirections

    
}//