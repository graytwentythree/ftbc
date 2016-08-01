using System;

public interface IInventoryItem
{
	void Drop();

	void Move(int index, int targetIndex);

	//IActorData? GetInfo();

	// might happen in the inventory
	//void DisplayInfo();
}

