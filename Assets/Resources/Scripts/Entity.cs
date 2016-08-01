using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class Entity : Actor {
	Controller controller;

	public static Entity Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		Entity actor = cube.AddComponent<Entity>();

		actor.id = lastId++;

		return cube.AddComponent<Entity>();
	}

	// Use this for initialization
	protected override void Awake () {
		controller = GetOrAddComponent<Controller>();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
