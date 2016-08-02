using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {

	protected Actor actor;
	protected Rigidbody rig;

	// Use this for initialization
	void Awake () {
		actor = GetComponent<Actor>();
		rig = actor.GetOrAddComponent<Rigidbody>();
	}

	protected virtual Vector3 GetMoveInput()
	{
		return new Vector3(0, 0, 0);
	}

	protected virtual void Move()
	{
		rig.velocity = GetMoveInput();
	}

	protected virtual void Interact(Interaction interactMode)
	{
		switch (interactMode)
		{
			case Interaction.ActivateBlock:
				break;
			case Interaction.DestroyBlock:
				break;
			case Interaction.PlaceBlock:
				break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
