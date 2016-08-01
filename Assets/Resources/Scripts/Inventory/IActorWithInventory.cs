using System;

public interface IActorWithInventory
{
	void StoreItem(IInventoryItem item);

	IInventoryItem GetItem(int index);

	void DisplayInventory();

	//void FindItem(int id);
}

