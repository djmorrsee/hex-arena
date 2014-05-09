//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
	public int id;
	public Grid grid;
	public Tile currentTile;
}

public abstract class StaticEntity : Entity
{
}

public abstract class ActiveEntity : Entity
{
}

public abstract class StationaryEntity : ActiveEntity
{
}

public abstract class MovableEntity : ActiveEntity
{
	public void Move (MoveDirection direction)
	{
		Tile requestedTile = grid.TileInDirectionFromTile (currentTile, direction);
		print (requestedTile);

		if (requestedTile.active && !requestedTile.occupied) {
			currentTile.Vacate ();
			requestedTile.Occupy (this);
			currentTile = requestedTile;
		}

	}
}

public abstract class AIEntity : MovableEntity
{
	public abstract void AITurn ();
}

public abstract class HeroEntity : MovableEntity, IAttackable, ISkillable
{
	public abstract int target {
		get;
		set;
	}
	public abstract void Attack ();
	public abstract void SkillOne ();
	public abstract void SkillTwo ();
	public abstract void SkillThree ();
	public abstract void SkillFour ();
}