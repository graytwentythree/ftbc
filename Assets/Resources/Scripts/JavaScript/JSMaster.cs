using UnityEngine;
using System.Collections;
using Jurassic;
using System;
using JSUtil;
using System.IO;
using Jurassic.Library;

public class JSMaster : MonoBehaviour {
	public static ScriptEngine engine;
	public static string MODULE_PATH;

	public static string codeString;

	// Use this for initialization
	void Awake ()
	{
		MODULE_PATH = Application.persistentDataPath + "/modules";

		InitializeJSEngine();

		//codeString = File.ReadAllText(MODULE_PATH + "/core/entities/player/main.js");

		//engine.Execute(codeString);

		ModuleLoader.LoadModules(MODULE_PATH);
	}

	void InitializeJSEngine()
	{
		engine = new ScriptEngine();

		engine.EnableExposedClrTypes = true;

		SetJavaScriptFunctions();
	}

	private void SetJavaScriptFunctions()
	{
		engine.SetGlobalFunction("print", new Action<string>(jsPrint));
	}

	public static void SetGlobalFunction(string str, Delegate fn)
	{
		engine.SetGlobalFunction(str, fn);
	}

	public static void ExecuteFile(string path)
	{
		engine.Execute(File.ReadAllText(path));
	}

	public static void SetInstanceFunction(string str, Delegate func, ObjectInstance jsObject) 
	{
		engine.SetGlobalFunction(str, func);

		var myFunc = (FunctionInstance)engine.Global[str];

		jsObject.SetPropertyValue(str, myFunc, false);

		// Optional clean up
		engine.Global.Delete(str, false);
	}

	#region JavaScript API

	public void jsPrint(string str) { print(str); }

	#endregion
}
