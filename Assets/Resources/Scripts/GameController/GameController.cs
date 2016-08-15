using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		Vector3 genPos = Vector3.one;
		genPos.z += 1;

		JSMaster.actorStore["generator"].Spawn(genPos);
		JSMaster.actorStore["battery"].Spawn(Vector3.one);
	}
}

public enum Interaction { PlaceBlock, DestroyBlock, ActivateBlock }