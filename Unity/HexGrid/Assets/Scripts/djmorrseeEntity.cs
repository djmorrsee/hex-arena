//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public class djmorrseeEntity : HeroEntity
{

	void Update ()
	{
		transform.position = currentTile.worldLocation;
		if (Input.GetKeyDown (KeyCode.W)) {
			Move (MoveDirection.upl);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			Move (MoveDirection.upr);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			Move (MoveDirection.left);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Move (MoveDirection.right);
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			Move (MoveDirection.downl);
		} else if (Input.GetKeyDown (KeyCode.X)) {
			Move (MoveDirection.downr);
		}
	}	

	public override int target {
		get;
		set;
	}

	// Basic Attacks
	public override void Attack ()
	{
	
	}


	// Skills 
	public override void SkillOne ()
	{
	
	}
	
	public override void SkillTwo ()
	{
	
	}
	
	public override void SkillThree ()
	{
	
	}
	
	public override void SkillFour ()
	{
	
	}	
	
}
