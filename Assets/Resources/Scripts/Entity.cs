using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Controller))]
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
