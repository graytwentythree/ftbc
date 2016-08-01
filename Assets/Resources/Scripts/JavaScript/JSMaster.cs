using UnityEngine;
using System.Collections;
using Jurassic;
using System;
using JSUtil;
using System.IO;

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
		engine.SetGlobalFunction("printSomething", new Action<string>(jsPrintSomething));
	}

	public static void SetGlobalFunction(string str, Delegate fn)
	{
		engine.SetGlobalFunction(str, fn);
	}

	public static void ExecuteFile(string path)
	{
		engine.Execute(File.ReadAllText(path));
	}

	#region JavaScript API

	public void jsPrintSomething(string str) { print(str); }

	#endregion
}
