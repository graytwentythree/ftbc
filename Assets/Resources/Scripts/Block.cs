using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : Actor {

	public static Block Spawn(Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		cube.AddComponent<BoxCollider>();

		return cube.AddComponent<Block>();
	}

	public Vector3 GetAdjacentBlockPosition(Vector3 hitPos)
	{
		float newX = hitPos.x > transform.position.x ? 1 : -1;
		float newY = hitPos.y > transform.position.y ? 1 : -1;
		float newZ = hitPos.z > transform.position.z ? 1 : -1;

		print(hitPos.x - transform.position.x);

		return new Vector3(newX, newY, newZ);
	}
}
