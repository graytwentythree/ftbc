using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// The Entity Component is attached to any intelligent actor.
/// This would include enemy monsters, players, and others.
/// 
/// Every entity requires a controller which determines what it does
/// and why. For example, the player entity's controller governs
/// player movement and controls based on user input. 
/// </summary>

[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(Stats))]
public class Entity : Actor, IActorWithInventory {

	#region Member Variables

	Controller controller;

	#endregion

	#region Monobehaviour functions

	protected override void Awake() {
		controller = GetOrAddComponent<Controller>();
		gameObject.layer = LayerMask.NameToLayer(LayerHelper.ENTITY_LAYER);
	}

	#endregion

	public static Entity Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		Entity actor = cube.AddComponent<Entity>();

		actor.id = lastId++;

		return cube.AddComponent<Entity>();
	}

	#region Inventory Functions

	public IStoreable GetItem(int index)
	{
		if (index < 0 || index >= inventory.Length)
			return null;

		return inventory[index];
	}

	public void StoreItem(IStoreable item)
	{
		throw new NotImplementedException();
	}

	public void DisplayInventory()
	{
	}

	#endregion
}
