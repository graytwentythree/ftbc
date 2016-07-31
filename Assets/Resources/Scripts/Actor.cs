using System;
using System.Collections;
using UnityEngine;

using Jurassic;
using Jurassic.Library;
using JSUtil;

[RequireComponent(typeof(Stats))]
public class Actor : MonoBehaviour
{
	ScriptEngine engine;
	public static string codeString = "PrintSomething(GetPos().x + ', ' + GetPos().y + ', ' + GetPos().z);";

	public T GetOrAddComponent<T>() where T : Component
	{
		return GetComponent<T>() ? GetComponent<T>() : gameObject.AddComponent<T>();
	}

	protected virtual void Awake()
	{
		engine = new ScriptEngine();

		engine.EnableExposedClrTypes = true;

		engine.SetGlobalFunction("GetPos", new Func<JSVectorInstance>(jsGetPos));
		engine.SetGlobalFunction("PrintSomething", new Action<string>(jsPrintSomething));
	}

	void Update()
	{
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

	#endregion

}
