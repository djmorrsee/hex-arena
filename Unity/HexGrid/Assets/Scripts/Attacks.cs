//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;


public interface IAttackable
{
	int target {
		get;
		set;
	}
	
	void Attack ();
}

public interface ISkillable
{
	
	void SkillOne ();
	
	void SkillTwo ();
	
	void SkillThree ();
	
	void SkillFour ();
}