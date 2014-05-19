//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGStats : MonoBehaviour
{
	
	public List<int> levelRequirements = new List<int> ();

	////////////////////////////////
	//// Class Variables 
	////////////////////////////////
	// Public
	public int hp;
	public int rhp;
	public int dhp;
	
	public int up;
	public int rup;
	public int dup;
	
	public int moveCost;
	public int attackCost;
	
	public int attackPower;
	public int dap;
	
	public int defensePower;
	public int ddp;
	
	int xp = 0;
	
	// Private

	

	////////////////////////////////
	//// Mono Methods
	////////////////////////////////
	void Start ()
	{
		levelRequirements.Add (0);
		levelRequirements.Add (100);
		levelRequirements.Add (250);
		levelRequirements.Add (500);
		levelRequirements.Add (1000);
		
	}

	void Update ()
	{

	}
	/*
	void FixedUpdate () {

	}

	void OnGUI () {

	}
	*/
	
	////////////////////////////////
	//// Class Methods 
	////////////////////////////////
	// Public
	public void InstantiateHero (int _hp, int _up, int _mc, int _ac, int _ap, int _dp)
	{
		hp = _hp;
		up = _up;
		moveCost = _mc;
		attackCost = _ac;
		attackPower = _ap;
		defensePower = _dp;
				
	}

	float a_co = .025f;
	float r_co = .025f;
	public void Attack (RPGStats other)
	{
		int ap = (int)(attackPower * up * a_co);
		int dp = (int)(other.defensePower);
		
		float reduc = ((r_co * dp) / (1 + r_co * dp));
		
		int damage = (int)(ap * (1f - reduc));
		
		print (string.Format ("A: {0} D: {1} DA:{2} R:{3}%", ap, dp, damage, reduc));
		
		if (damage > 0) {
			other.DecreaseHP (damage);
		}
		
		DecreaseUP (attackCost);
	}
	
	public void Move ()
	{
		DecreaseUP (moveCost);
	}
	
	public bool CanMove ()
	{
		return up >= moveCost;
	}
	
	public bool CanAttack ()
	{
		return up >= attackCost;
	}
	
	// Private
	void DecreaseHP (int amount)
	{
		if (hp == 0)
			return;
	
		hp -= amount;
		if (hp < 0) {
			hp = 0;
		}
	}
	
	void DecreaseUP (int amount)
	{
		if (up == 0)
			return;
			
		up -= amount;
		if (up < 0) {
			up = 0;
		}
	}
	
	public void IncreaseXP (int amount)
	{
		int i = 0, j = 0;
		foreach (int k in levelRequirements) {
			if (xp > k) {
				i = k;
			}
		}
		
		xp += amount;
		foreach (int k in levelRequirements) {
			if (xp > k) {
				j = k;
			}
		}
		if (i != j) {
			LevelUp (levelRequirements.IndexOf (j));
			
		}
	}
	
	public void LevelUp (int level)
	{
		print (level);
	}
}

