using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// These should all be the last logical block loaded
		// from the module loader
		LogicalBlock.Spawn(JSMaster.logicalBlockStore[0], Vector3.one * 4);
		LogicalBlock.Spawn(JSMaster.logicalBlockStore[1], Vector3.one * -4);
		LogicalBlock.Spawn(JSMaster.logicalBlockStore[0], Vector3.one * 4);
		LogicalBlock.Spawn(JSMaster.logicalBlockStore[1], Vector3.one * -4);
	}
}
