using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;
using System;

public class LogicalBlock : Block, IProgrammable
{
	public ObjectInstance jsObject;

	public static LogicalBlock Spawn(LogicalBlockData data, Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		LogicalBlock actor = cube.AddComponent<LogicalBlock>();

		actor.name = data.name;

		actor.id = lastId++;

		actor.RefreshJSObject(data.path);

		actor.SetJSMemberFunctions();

		actor.jsAwake();

		return actor;
	}

	protected override void Update()
	{
		base.Update();

		Tick();
	}

	protected override ObjectInstance GetJSObject()
	{
		return jsObject;
	}

	public void RefreshJSObject(string path)
	{
		// if we execute the script that belongs to this type, we can grab the correct mainobject.
		JSMaster.ExecuteFile(path);

		// Get main object created by modder
		var mainObject = JSMaster.engine.GetGlobalValue<ObjectInstance>("mainObject");

		// Set the name to be this thing's name + its id as a unique identifier
		JSMaster.engine.SetGlobalValue(gameObject.name + id, mainObject);

		// Store a reference to the unique identifier once
		jsObject = (ObjectInstance)JSMaster.engine.Global[gameObject.name + id];
	}

	#region JS API Wrappers

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

	#endregion

	#region JS API Functions

	public ObjectInstance jsGetAdjacentBlockObject(string direction)
	{
		Vector3 dir = dirs[direction.ToLower()];

		print(GetAdjacentBlockObject(dir));

		return GetAdjacentBlockObject(dir);
	}

	#endregion

	// Sets all JS API functions on the javascript object representing this LogicalBlock
	private void SetJSMemberFunctions()
	{
		JSMaster.SetInstanceFunction("getAdjacentBlock",
									 new Func<string, ObjectInstance>(jsGetAdjacentBlockObject),
									 jsObject);
	}
}

/// <summary>
/// The LogicalBlockData struct represents the data of a certain logical block type.
/// For example, if the user wanted to spawn a generator, the generator LogicalBlockData
/// could be fetched from memory by ID, and then an instance of a generator
/// may be spawned using the fetched data.
/// </summary>
public struct LogicalBlockData
{
	public LogicalBlockData(string name, int id, string path)
	{
		this.name = name;
		this.id = id;
		this.path = path;
	}

	public string name;
	public int id;
	public string path;
}

