using System;
using System.IO;
using System.Linq;
using Jurassic.Library;
using UnityEngine;

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

	// Loads a module at a given path
	private static void LoadModule(string path)
	{
		// All actor type directories in a module (entities, blocks...)
		foreach (string dir in Directory.GetDirectories(path))
		{
			LoadActors(dir);
		}
	}

	// Loads all the actors from a type of actor's directory.
	// i.e. Load all blocks from the block directory
	private static void LoadActors(string path)
	{
		// All actor directories within an actor type directory
		foreach (string dir in Directory.GetDirectories(path))
		{
			LoadActor(dir);
		}
	}

	// Loads an actor based on its directory
	private static void LoadActor(string dir)
	{
		RunScript(dir + MAIN_SCRIPT_NAME);
		StoreActorData(dir);
	}

	private static void RunScript(string path)
	{
		JSMaster.ExecuteFile(path);
	}

	private static void StoreActorData(string path)
	{
		// Store data of block including the id and path to js file to run when spawning
		string name = path.Split('/').Last();
		
		var blockData = new ActorData(name, JSMaster.actorStore.Count, path + MAIN_SCRIPT_NAME);

		// Old list
		//JSMaster.actorStore.Add(blockData);

		// New dictionary. Gives id from list of keys, name as key.
		JSMaster.actorStore.Add(name.ToLower(), blockData);
	}
}