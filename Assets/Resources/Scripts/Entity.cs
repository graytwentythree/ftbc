using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class Entity : Actor {
	Controller controller;

	// Use this for initialization
	protected override void Awake () {
		controller = GetOrAddComponent<Controller>();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
