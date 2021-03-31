using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseMoveEventArgs : ExtendedEventArgs
{
	public int id { get; set; } // The x coordinate of the target location
	public float x { get; set; } // The y coordinate of the target location
	public float y { get; set; }
	public float t { get; set; }

	public ResponseMoveEventArgs()
	{
		event_id = Constants.SMSG_MOVE;
	}
}

public class ResponseMove : NetworkResponse
{
	
	private int id;
	private float x;
	private float  y;
	private float t;

	public ResponseMove()
	{
	}

	public override void parse()
	{
		id = DataReader.ReadInt(dataStream);
		x = DataReader.ReadInt(dataStream);
		y = DataReader.ReadInt(dataStream);
		t = DataReader.ReadInt(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseMoveEventArgs args = new ResponseMoveEventArgs
		{
			id = id,
			x = x,
			y = y,
			t = t
		};

		return args;
	}
}
