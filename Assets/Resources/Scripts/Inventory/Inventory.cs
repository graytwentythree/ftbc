using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

/// <summary>
/// The Inventory component is attached to an entity gameobject. 
/// It represents a structure containing an arbitrary number of items;
/// </summary>
public class Inventory : MonoBehaviour {

	#region Member Variables
	List<InventorySlot> slots = new List<InventorySlot>();

	public int maxItems = 27;
	#endregion

	// Populates inventory with empty items;
	void Awake()
	{
		for (int i = 0; i < 26; i++)
		{
			slots.Add(new InventorySlot(null));
		}

		slots.Add(new InventorySlot(new Item(new ItemData("swordLol", 1, "items/lolololol"))));

		print(slots[26].GetItem().GetInfo().name);
	}

	InventorySlot GetNextAvailableStack(IStoreable item)
	{
		foreach (InventorySlot slot in slots)
		{
			if (slot.CompatibleWith(item))
			{
				return slot;
			}
		}

		return null;
	}

	public void Add(IStoreable item)
	{
		GetNextAvailableStack(item).AddItem(item);
	}

	public void Remove(IStoreable item)
	{
		GetNextAvailableStack(item).RemoveItem(item);
	}

	public void RemoveAt(int index, int amount = 1)
	{
		slots[index].RemoveItem(amount);
	}

}

/// <summary>
/// The InventorySlot class represents a slot in an inventory.
/// It contains functions to check the state of the slot.
/// 
/// An Inventory type encapsulates an InventorySlot class 
/// as an array of slots. The slot's functions are used
/// to determine how to interact with a slot when manipulating
/// an inventory.
/// </summary>
public class InventorySlot
{
	IStoreable item;
	int count;

	public InventorySlot(IStoreable item)
	{
		this.item = item;
		count = 0;
	}

	public bool IsFull()
	{
		return count >= item.GetMaxStack();
	}

	public bool IsEmpty()
	{
		return item == null || count <= 0;
	}

	public bool CompatibleWith(IStoreable item)
	{
		if (IsFull()) return false;

		return this.item == null || this.item.Equals(item);
	}

	public void AddItem(IStoreable item)
	{
		if (!CompatibleWith(item)) return;
		count += 1;
	}

	public void RemoveItem(IStoreable item)
	{
		if (!this.item.Equals(item)) return;
		count -= 1;

		if (count == 0)
		{
			item = null;
		}
	}

	public void RemoveItem(int num)
	{
		count -= num;

		if (count == 0)
		{
			item = null;
		}
	}

	public IStoreable GetItem()
	{
		return item;
	}
	//public void Drop()
	//{
		
	//}
}
