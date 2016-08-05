using System;

public interface IStoreable
{
	void Drop();

	void Move(int index, int targetIndex);

	//void Store(Inventory inventory);

	ItemData GetInfo();

	bool Equals(IStoreable storeable);

	int GetMaxStack();

	// might happen in the inventory
	//void DisplayInfo();
}

