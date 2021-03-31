using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestMove : NetworkRequest
{
	public RequestMove()
	{
		request_id = Constants.CMSG_MOVE;
	}

	public void send(int id, float x, float y, float t)
	{
		packet = new GamePacket(request_id);
		packet.addInt32(id);
		packet.addFloat32(x);
		packet.addFloat32(y);
		packet.addFloat32(t);
		
	}
}
