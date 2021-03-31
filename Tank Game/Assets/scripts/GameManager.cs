using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Player[] Players = new Player[2];
	public GameObject HeroPrefab1;
	public GameObject HeroPrefab2;

	private int currentPlayer = 1;
	
	public bool isSingle;
	public NetworkManager networkManager;

	private GameObject heroObj1;
	private GameObject heroObj2;
	private mover hero1;
	private mover2 hero2;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
		MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
		msgQueue.AddCallback(Constants.SMSG_MOVE, OnResponseMove);
		msgQueue.AddCallback(Constants.SMSG_INTERACT, OnResponseInteract);
	}

	public Player GetCurrentPlayer()
	{
		return Players[currentPlayer - 1];
	}

	public void Init(Player player1, Player player2, bool single)
	{
		Players[0] = player1;
		Players[1] = player2;
		isSingle = single;
	}

	public void CreateHeroes()
	{
		
		heroObj1 = Instantiate(HeroPrefab1, new Vector3(0, 0, 50), Quaternion.identity);
		heroObj1.GetComponentInChildren<Renderer>().material.color = Players[0].Color;
		hero1 = heroObj1.GetComponent<mover>();
		Players[0].move = hero1;
		
		

		heroObj2 = Instantiate(HeroPrefab2, new Vector3(0, 0, -50), new Quaternion(0, -180, 0, 0));
		heroObj2.GetComponentInChildren<Renderer>().material.color = Players[1].Color;
		hero2 = heroObj2.GetComponent<mover2>();
		Players[1].move2 = hero2;
		
		
	}


	public void ProcessMove(int id, float x, float y, float t)
	{
		networkManager.SendMoveRequest(id, x, y, t);
	}

	

	public void OnResponseMove(ExtendedEventArgs eventArgs)
	{
		ResponseMoveEventArgs args = eventArgs as ResponseMoveEventArgs;
		if(args.id == Players[0].UserID){
			
			hero1.Move(args.x, args.y);
		}
		else if(args.id == Players[1].UserID){
			
			hero2.Move(args.x, args.y);
		}else
		{
			Debug.Log("ERROR: Invalid user_id in ResponseReady: " + args.id);
		}
	}

	public void OnResponseInteract(ExtendedEventArgs eventArgs)
	{
		ResponseInteractEventArgs args = eventArgs as ResponseInteractEventArgs;
		if (args.user_id == Constants.OP_ID)
		{
			int pieceIndex = args.piece_idx;
			int targetIndex = args.target_idx;
		}
		else if (args.user_id == Constants.USER_ID)
		{
			// Ignore
		}
		else
		{
			Debug.Log("ERROR: Invalid user_id in ResponseReady: " + args.user_id);
		}
	}
}
