using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;
using System;

public class Block : Actor {

	protected override void Awake()
	{
		base.Awake();
		gameObject.layer = LayerMask.NameToLayer(LayerHelper.BLOCK_LAYER);
	}

	public static Block Spawn(BlockData data, Vector3 position)
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;

		Block actor = cube.AddComponent<Block>();

		actor.id = lastId++;

		actor.name = data.name;

		actor.SetupJSObject(data);

		return actor;
	}

	public Vector3 GetAdjacentBlockPosition(Vector3 hitPos)
	{
		float newX = hitPos.x > transform.position.x ? 1 : -1;
		float newY = hitPos.y > transform.position.y ? 1 : -1;
		float newZ = hitPos.z > transform.position.z ? 1 : -1;

		print(hitPos.x - transform.position.x);

		return new Vector3(newX, newY, newZ);
	}
	
	public Block GetAdjacentBlock(Vector3 direction)
	{
		Block target = null;
		
		RaycastHit hitInfo;
		if (Physics.Raycast(transform.position, direction,
		                    out hitInfo, .5f, LayerHelper.LayerToLayerMask(gameObject.layer)))
		{
			target = hitInfo.transform.GetComponent<Block>();
		}
		
		return target;
	}

	// Returns the js object instance of a js-serializeable block
	public ObjectInstance GetAdjacentBlockObject(Vector3 direction)
	{
		Block b = GetAdjacentBlock(direction);

		return b == null ? null : b.GetJSObject();
	}

	public ObjectInstance jsGetAdjacentBlockObject(string direction)
	{
		Vector3 dir = dirs[direction.ToLower()];

		return GetAdjacentBlockObject(dir);
	}

	protected override void SetJSMemberFunctions()
	{
		base.SetJSMemberFunctions();
		JSMaster.SetInstanceFunction("getAdjacentBlock",
									 new Func<string, ObjectInstance>(jsGetAdjacentBlockObject),
									 jsObject);
	}
}
