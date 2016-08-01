using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;

public class LogicalBlock : Block, IProgrammable
{
	ObjectInstance jsObject;

	public static LogicalBlock Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		LogicalBlock actor = cube.AddComponent<LogicalBlock>();

		actor.id = lastId++;

		actor.RefreshJSObject();

		return actor;
	}

	protected override void Update()
	{
		base.Update();

		Tick();
	}

	public void RefreshJSObject()
	{
		// Create a js object using name + id


		// Wait, this should not construct a new actor api.
		// It needs to be loading the object from a specified JS script.
		//var actorAPI = JSMaster.engine.Object.Construct();

		// Get main object created by modder
		var mainObject = JSMaster.engine.GetGlobalValue<ObjectInstance>("mainObject");

		// Set the name to be this thing's name + its id as a unique identifier
		JSMaster.engine.SetGlobalValue(gameObject.name + id, mainObject);

		// Store a reference to the unique identifier once
		jsObject = (ObjectInstance)JSMaster.engine.Global[gameObject.name + id];
	}

	public void Tick()
	{
		jsObject.CallMemberFunction("tick");
	}

	public void Activate()
	{
		jsObject.CallMemberFunction("activate");
	}
}


