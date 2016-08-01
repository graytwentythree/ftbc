using System;
using System.IO;
using UnityEngine;

public class ModuleLoader : MonoBehaviour {

	public const string MAIN_SCRIPT_NAME = "/main.js";

	public static void LoadModules(string path)
	{
		foreach (string dir in Directory.GetDirectories(path))
		{
			if (dir.Contains(".git")) continue;
			LoadModule(dir);
		}
	}

	public static void LoadModule(string path)
	{
		LoadLogicalBlocks(path);
	}

	public static void LoadLogicalBlocks(string path)
	{
		string logicalBlocksDir = path + "/logical-blocks";

		foreach (string dir in Directory.GetDirectories(logicalBlocksDir))
		{
			LoadScript(dir + MAIN_SCRIPT_NAME);
		}
	}

	public static void LoadScript(string path)
	{
		JSMaster.ExecuteFile(path);
	}
}
