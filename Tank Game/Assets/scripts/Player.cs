using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
	public int UserID { get; set; }
	public string Name { get; set; }
	public Color Color { get; set; }
	public mover[] Heroes { get; set; }

	public mover move { get; set; }

	public mover2 move2 { get; set; }
	

	private int heroCount = 0;

	public Player(int userID, string name, Color color, bool isMouseControlled)
	{
		UserID = userID;
		Name = name;
		Color = color;
		Heroes = new mover[1];
		
	}

	public void AddHero(mover hero)
	{
		Heroes[heroCount++] = hero;
		hero.Owner = this;
	}
}
