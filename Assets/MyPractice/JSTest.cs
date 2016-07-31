using UnityEngine;
using Jurassic;
using Jurassic.Library;
using System;

public class JSTest : MonoBehaviour
{
	ScriptEngine engine;
	public static string codeString = "PrintSomething(actor.type);";

	void Awake()
	{
		// Create an instance of the Jurassic engine then expose some stuff to it.
		engine = new ScriptEngine();

		// Arguments and returns of functions exposed to JavaScript must be of supported types.
		// Supported types are bool, int, double, string, Jurassic.Null, Jurassic.Undefined
		// and Jurassic.Library.ObjectInstance (or a derived type).
		// More info: http://jurassic.codeplex.com/wikipage?title=Supported%20types

		// Examples of exposing some static classes to JavaScript using Jurassic's "seamless .NET interop" feature.
		engine.EnableExposedClrTypes = true; // You must enable this in order to use interop feaure.
											 // Then pass the names and types of the classes you want to expose to SetGlobalValue().
											 //engine.SetGlobalValue("Mathf", typeof(Mathf));
											 //engine.SetGlobalValue("Input", typeof(Input));

		//engine.SetGlobalFunction("GetX", new System.Func<double>(jsGetX));
		engine.SetGlobalFunction("PrintSomething", new Action<string>(jsPrintSomething));

		var actor = engine.Object.Construct();
		actor["type"] = "fuckboy";

		engine.SetGlobalValue("actor", actor);
	}
	//new System.Delegate(jsPrintSomething)

	public double jsGetX() { return (double)transform.position.x; }
	public void jsPrintSomething(string str) { print(str); }

	void Start()
	{
		engine.Execute(codeString);
	}

	//void Update()
	//{
	//	engine.Execute(codeString);
	//}
}