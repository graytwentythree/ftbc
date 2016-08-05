using UnityEngine;
using System.Collections;
using System;


/// <summary>
/// This component is attached to items dropped in the world.
/// </summary>
public class Item : MonoBehaviour, IStoreable {

	public int id; 

	public static Item Spawn(ItemData data, Vector3 position)
	{
		return null;
	}

	//public void AddToInventory(IActorWithInventory actor)
	//{
	//	actor.StoreItem(this);
	//}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


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
		throw new NotImplementedException();
	}

	public bool Equals(IStoreable storeable)
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

