using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;
using System;

public class LogicalBlock : Block 
{
	public static LogicalBlock Spawn(ActorData data, Vector3 position)
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

	//protected override void Update()
	//{
	//	base.Update();

	//	//Tick();
	//}

	//protected override ObjectInstance GetJSObject()
	//{
	//	return jsObject;
	//}

	//public void RefreshJSObject(string path)
	//{
	//	// if we execute the script that belongs to this type, we can grab the correct mainobject.
	//	JSMaster.ExecuteFile(path);

	//	// Get main object created by modder
	//	var mainObject = JSMaster.engine.GetGlobalValue<ObjectInstance>("mainObject");

	//	// Set the name to be this thing's name + its id as a unique identifier
	//	JSMaster.engine.SetGlobalValue(gameObject.name + id, mainObject);

	//	// Store a reference to the unique identifier once
	//	jsObject = (ObjectInstance)JSMaster.engine.Global[gameObject.name + id];
	//}

	//#region JS API Wrappers

	//public void jsAwake()
	//{
	//	jsObject.CallMemberFunction("awake");
	//}

	//public void Tick()
	//{
	//	jsObject.CallMemberFunction("tick");
	//}

	//public void Activate()
	//{
	//	jsObject.CallMemberFunction("activate");
	//}

	//#endregion

	//#region JS API Functions



	//#endregion

	// Sets all JS API functions on the javascript object representing this LogicalBlock

	//void IProgrammable.RefreshJSObject(string path)
	//{
	//	throw new NotImplementedException();
	//}
}


