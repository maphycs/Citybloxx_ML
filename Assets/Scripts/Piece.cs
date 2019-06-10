﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public struct StackStatus
    {
        public bool isStackSuccessful;
        public int fallenSide;
        public bool isDeadCenter;
    }
    public StackStatus stackStatus;

    public bool isHooked = false;
    public bool isStacked = true;
    public float deadCenterRange = 0.15f;

	private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(isHooked)
    	{
	        if(Input.GetKeyDown("space"))
	        {
	        	transform.parent = null;
                Vector3 p = transform.position;
                p.z = 0;
                transform.position = p;
	        	transform.rotation = Quaternion.Euler(0,0,0);
	        	rb2d.isKinematic = false;
	        	isHooked = false;
	        }
    	}
    }

    void OnCollisionEnter2D()
    {
        if(!isStacked)
        {
            GameControl.instance.OnPieceStacking();
            rb2d.isKinematic = true;
            rb2d.velocity = Vector3.zero;
            parent2Column();        
        }
    }

    void parent2Column()
    {
        transform.SetParent(GameControl.instance.columnObj.transform, true);
        // set the rotation for subObject using this way
        transform.localEulerAngles = Vector3.zero;
        rb2d.angularVelocity = 0;
    }

    void OnCollisionExit2D(Collision2D ctl)
    {
        if(!isStacked && ctl.collider.gameObject.tag == "Piece")
        {
            if(checkIfCanStack(ctl))
            {
                stackStatus.isStackSuccessful = true;
                GameControl.instance.AfterPieceStackingSuccessfully(stackStatus.isDeadCenter);
            }
            else
            {
                stackStatus.isStackSuccessful = false;
                GameControl.instance.AfterPieceStackingFailed(stackStatus.fallenSide);
                OnStackingFailed();
            }
        }
        isStacked = true;
    }

    private bool checkIfCanStack(Collision2D ctl)
    {
        float topPiecePosX = ctl.collider.transform.localPosition.x;
        float dropPiecePosX = ctl.otherCollider.transform.localPosition.x;
        float deltaX = dropPiecePosX - topPiecePosX;
        float absDeltaX = Mathf.Abs(deltaX);
        
        if(absDeltaX < 0.5)
        {
            checkIfDeadCenter(absDeltaX, topPiecePosX, ctl.otherCollider);
            Debug.Log(ctl.collider.gameObject.name + "  " + ctl.collider.transform.localPosition.x + " | " 
                + ctl.otherCollider.gameObject.name + "  " + ctl.otherCollider.transform.localPosition.x + " || " + "drop true");
            return true;
        }
        else 
        {
            checkFallenSide(deltaX);
            Debug.Log(ctl.collider.gameObject.name + "  " + ctl.collider.transform.localPosition.x + " | " 
                + ctl.otherCollider.gameObject.name + "  " + ctl.otherCollider.transform.localPosition.x + " || " + "drop false");
            return false;
        }
    }

    private void checkIfDeadCenter(float absDeltaX, float topPiecePosX, Collider2D other)
    {
        if(absDeltaX < deadCenterRange)
        {
            stackStatus.isDeadCenter = true;
            Vector3 pos = other.transform.localPosition;
            pos.x = topPiecePosX;
            other.transform.localPosition = pos;
        }
        else
        {
            stackStatus.isDeadCenter = false;
        }
    }

    private void checkFallenSide(float deltaX)
    {
        if(deltaX > 0)
        {
            stackStatus.fallenSide = 1;
        }
        else
        {
            stackStatus.fallenSide = -1;
        }
        // Debug.Log("fallen side = " + stackStatus.fallenSide);
    }

    private void OnStackingFailed()
    {
        transform.parent = null;
        transform.position = new Vector3(0, -10f, 0);
    }

}
