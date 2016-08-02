using System;
using System.IO;
using System.Linq;
using Jurassic.Library;

/// <summary>
/// The ModuleLoader class contains static functions to load 
/// all modules for the game. This means all 
/// actors, blocks, entities, logical blocks, 
/// and other items will be loaded into the game
/// by these functions.
/// </summary>
public class ModuleLoader
{
	public const string MAIN_SCRIPT_NAME = "/main.js";
	public const string MAIN_OBJECT_NAME = "mainObject";

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
		LoadBlocks(path);
		LoadLogicalBlocks(path);
		LoadEntities(path);
	}

	public static void LoadLogicalBlocks(string path)
	{
		string logicalBlocksDir = path + "/logical-blocks";

		foreach (string dir in Directory.GetDirectories(logicalBlocksDir))
		{
			LoadActor(dir + MAIN_SCRIPT_NAME);

			StoreLogicalBlockData(dir);
		}
	}

	private static void StoreLogicalBlockData(string path)
	{
		//var mainObject = JSMaster.engine.GetGlobalValue<ObjectInstance>("mainObject");

		// Store data of block including the id and path to js file
		// id is used to grab the correct block from the LogicalBlock component
		// path is run in the Logical Block component whenever a block is spawned.
		// That was, the main object is reset and used again to store an instance object
		// representing the logic of a specific logical block.
		string name = path.Split('/').Last();

		var blockData = new LogicalBlockData(name, JSMaster.logicalBlockStore.Count, path + MAIN_SCRIPT_NAME);

		JSMaster.logicalBlockStore.Add(blockData);
	}

	public static void LoadEntities(string path)
	{
		string entitiesDir = path + "/entities";

		foreach (string dir in Directory.GetDirectories(entitiesDir))
		{
			LoadActor(dir + MAIN_SCRIPT_NAME);
		}
	}

	public static void LoadBlocks(string path)
	{
		string blocksDir = path + "/blocks";

		foreach (string dir in Directory.GetDirectories(blocksDir))
		{
			//LoadActor(dir + MAIN_SCRIPT_NAME);
		}
	}

	public static void LoadActor(string path)
	{
		RunScript(path);
	}

	static void RunScript(string path)
	{
		JSMaster.ExecuteFile(path);
	}
}