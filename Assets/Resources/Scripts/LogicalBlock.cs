using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;
using System;

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

		actor.jsAwake();

		return actor;
	}

	protected override void Update()
	{
		base.Update();

		Tick();
	}

	public void RefreshJSObject()
	{
		// Get main object created by modder
		var mainObject = JSMaster.engine.GetGlobalValue<ObjectInstance>("mainObject");

		// Set the name to be this thing's name + its id as a unique identifier
		JSMaster.engine.SetGlobalValue(gameObject.name + id, mainObject);

		// Store a reference to the unique identifier once
		jsObject = (ObjectInstance)JSMaster.engine.Global[gameObject.name + id];

		JSMaster.engine.Function.Construct();
	}

	public void jsAwake()
	{
		jsObject.CallMemberFunction("awake");
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


