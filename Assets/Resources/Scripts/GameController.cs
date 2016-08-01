using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LogicalBlock.Spawn(Vector3.one * 4);
		//LogicalBlock.Spawn(Vector3.one * 4);
		//LogicalBlock.Spawn(Vector3.one * 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
