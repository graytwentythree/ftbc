using System;

public interface IActorWithInventory
{
	void StoreItem(IStoreable item);

	IStoreable GetItem(int index);

	void DisplayInventory();

	//void FindItem(int id);
}

