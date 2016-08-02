using System;
using System.Collections;
using UnityEngine;

using Jurassic;
using Jurassic.Library;
using JSUtil;
using System.IO;
using System.Reflection;

public class Actor : MonoBehaviour
{
	public static int lastId = 0;

	protected int id;

	public T GetOrAddComponent<T>() where T : Component
	{
		return GetComponent<T>() ? GetComponent<T>() : gameObject.AddComponent<T>();
	}

	public static Actor Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		Actor actor = cube.AddComponent<Actor>();

		actor.id = lastId++;

		return actor;
	}

	protected virtual void Awake()
	{
		gameObject.layer = LayerMask.NameToLayer(LayerHelper.ACTOR_LAYER);
	}

	protected virtual void Update()
	{
	}

	protected virtual ObjectInstance GetJSObject()
	{
		return null;
	}

	#region JavaScript API Functions

	//Creates a JS Vector using transform position
	public JSVectorInstance jsGetPos() { 
		return new JSVectorConstructor(JSMaster.engine).Construct(
			(double)transform.position.x,
			(double)transform.position.y,
			(double)transform.position.z);
	}

	public void jsSetPos(double x, double y, double z)
	{
		transform.position = new Vector3((float)x, (float)y, (float)z);
	}

	#endregion

}

public struct ActorData
{
}

