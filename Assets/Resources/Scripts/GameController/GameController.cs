using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		// Assault and battery

		Vector3 genPos = Vector3.one;
		genPos.z += 1;
		LogicalBlock.Spawn(JSMaster.actorStore["generator"], genPos);
		LogicalBlock.Spawn(JSMaster.actorStore["battery"], Vector3.one);
	}


}

public enum Interaction { PlaceBlock, DestroyBlock, ActivateBlock }