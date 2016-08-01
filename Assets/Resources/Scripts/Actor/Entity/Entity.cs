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
	Controller controller;

	IInventoryItem[] inventory = new IInventoryItem[27]; 

	public static Entity Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		Entity actor = cube.AddComponent<Entity>();

		actor.id = lastId++;

		return cube.AddComponent<Entity>();
	}

	public IInventoryItem GetItem(int index)
	{
		if (index < 0 || index >= inventory.Length)
			return null;

		return inventory[index];
	}

	public void StoreItem(IInventoryItem item)
	{
		throw new NotImplementedException();
	}

	public void DisplayInventory()
	{
	}

	// Use this for initialization
	protected override void Awake () {
		controller = GetOrAddComponent<Controller>();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
