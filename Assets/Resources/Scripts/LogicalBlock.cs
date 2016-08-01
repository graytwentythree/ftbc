using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;

public class LogicalBlock : Block, IProgrammable
{
	public static LogicalBlock Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		LogicalBlock actor = cube.AddComponent<LogicalBlock>();

		actor.id = lastId++;

		actor.CreateJSObject();

		return cube.AddComponent<LogicalBlock>();
	}

	protected override void Update()
	{
		base.Update();

		//Tick();
	}

	public void CreateJSObject()
	{
		// Create a js object using name + id


		// Wait, this should not construct a new actor api.
		// It needs to be loading the object from a specified JS script.
		//var actorAPI = JSMaster.engine.Object.Construct();

		//print(JSMaster.engine.GetGlobalValue("mainObject"));
	}

	public void Tick()
	{
		var jsObject = (ObjectInstance)JSMaster.engine.Global[gameObject.name + id];

		jsObject.CallMemberFunction("tick");
	}
}


