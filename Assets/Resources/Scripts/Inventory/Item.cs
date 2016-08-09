using UnityEngine;
using System.Collections;
using System;
using Jurassic.Library;


/// <summary>
/// This component is attached to items dropped in the world.
/// </summary>
public class Item : IStoreable {

	public int id;
	public string name;
	public ItemData data;

	public static Item Spawn(ItemData data, Vector3 position)
	{
		return null;
	}

	public Item(ItemData data)
	{
		this.name = data.name;
		this.data = data;
	}

	//public void AddToInventory(IActorWithInventory actor)
	//{
	//	actor.StoreItem(this);
	//}

	public override bool Equals(object o)
	{
		Item item = (Item) o;

		return item.id == this.id;
	}

	public int GetMaxStack()
	{
		return 64;
	}

	public void Drop()
	{
		throw new NotImplementedException();
	}

	public void Move(int index, int targetIndex)
	{
		throw new NotImplementedException();
	}

	public ItemData GetInfo()
	{
		return data;
	}

	public bool Equals(IStoreable storeable)
	{
		throw new NotImplementedException();
	}

	public ObjectInstance GetJSObject()
	{
		throw new NotImplementedException();
	}
}

public class ItemData
{
	public string name;
	public int id;
	public string path;

	public ItemData(string name, int id, string path)
	{
		this.name = name;
		this.id = id;
		this.path = path;
	}

	public virtual Item Spawn(Vector3 position)
	{
		return Item.Spawn(this, position);
	}
}

