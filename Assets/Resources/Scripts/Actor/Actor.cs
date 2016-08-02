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

/// <summary>
/// The LogicalBlockData struct represents the data of a certain logical block type.
/// For example, if the user wanted to spawn a generator, the generator LogicalBlockData
/// could be fetched from memory by ID, and then an instance of a generator
/// may be spawned using the fetched data.
/// </summary>
public struct ActorData
{
	public ActorData(string name, int id, string path)
	{
		this.name = name;
		this.id = id;
		this.path = path;
	}

	public string name;
	public int id;
	public string path;
}

