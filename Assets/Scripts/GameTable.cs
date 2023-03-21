using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTable
{
	/* The doubling value */
	private bool isDoublerOn;
	
	/* If the game is drawn, then it takes the true value*/
	private bool doublerSession;

    /* Variable to show if the game is started*/
    private bool isStarted;

    /* property to set game started*/
    public bool IsStarted
    {
        set { isStarted = value; }
        get { return isStarted; }
    }

    /* Variable to show if the game is finished*/
    private bool isFinished;

    /* property to set game finished*/
    public bool IsFinished
    {
        set { isFinished = value; }
        get { return isFinished; }
    }

    /* places to put dominoes */
    private int leftPlace;
	private int rightPlace;
	private int downPlace;
	private int upPlace;

    /* properties to set coordinates*/
    public int LeftPlace
    {
        set { leftPlace = value; }
        get { return leftPlace; }
    }

    public int RightPlace
    {
        set { rightPlace = value; }
        get { return rightPlace; }
    }

    public int DownPlace
    {
        set { downPlace = value; }
        get { return downPlace; }
    }

    public int UpPlace
    {
        set { upPlace = value; }
        get { return upPlace; }
    }

    /* head and tail of the board*/
    private uint head;
    private uint tail;

    /* properties to set head and tail dominoes*/
    public uint Head
    {
        set { head = value; }
        get { return head; }
    }

    public uint Tail
    {
        set { tail = value; }
        get { return tail; }
    }

    //private bool isClosed;
    //private bool isStarted;

    public GameTable(int numberOfPlayersPassed, bool isDoublerPassed, bool doublerSessionPassed)
	{
		/* Gets the doubling value */
		isDoublerOn = isDoublerPassed;

		isStarted = true;

        isFinished = false;
		
		doublerSession = doublerSessionPassed;
	}


}
