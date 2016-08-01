using System.IO;

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
		}
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