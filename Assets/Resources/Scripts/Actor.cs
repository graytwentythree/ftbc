using System;
using System.Collections;
using UnityEngine;

using Jurassic;
using Jurassic.Library;
using JSUtil;
using System.IO;

[RequireComponent(typeof(Stats))]
public class Actor : MonoBehaviour
{
	public const string JAVASCRIPT_PATH = "Assets/Resources/JavaScripts/";

	ScriptEngine engine;
	//public string scriptPath;
	public string codeString = "PrintSomething(GetPos().x + ', ' + GetPos().y + ', ' + GetPos().z);";

	public T GetOrAddComponent<T>() where T : Component
	{
		return GetComponent<T>() ? GetComponent<T>() : gameObject.AddComponent<T>();
	}

	protected virtual void Awake()
	{
		engine = new ScriptEngine();

		engine.EnableExposedClrTypes = true;

		engine.SetGlobalFunction("getPos", new Func<JSVectorInstance>(jsGetPos));
		engine.SetGlobalFunction("setPos", new Action<double, double, double>(jsSetPos));
		engine.SetGlobalFunction("printSomething", new Action<string>(jsPrintSomething));

		// Every time an actor is made, his main script is run
		codeString = File.ReadAllText(JAVASCRIPT_PATH + "actor.njs");

		engine.Execute(codeString);
	}

	protected virtual void Update()
	{
		// Every frame, the actor's tick function is called.
		engine.CallGlobalFunction("tick");

		// extract tick function
		//engine.Execute(codeString);
	}

	#region JavaScript API Functions

	public void jsPrintSomething(string str) { print(str); }

	// Creates a JS Vector using transform position
	public JSVectorInstance jsGetPos() { 
		return new JSVectorConstructor(engine).Construct(
			(double)transform.position.x,
			(double)transform.position.y,
			(double)transform.position.z);
	}

	public void jsSetPos(double x, double y, double z)
	{
		transform.position = new Vector3((float)x, (float)y, (float)z);
	}

	#endregion

}
