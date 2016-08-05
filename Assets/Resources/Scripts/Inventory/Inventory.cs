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
		for (int i = 0; i < 27; i++)
		{
			slots.Add(new InventorySlot(null));
		}
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
	//public void Drop()
	//{
		
	//}
}
