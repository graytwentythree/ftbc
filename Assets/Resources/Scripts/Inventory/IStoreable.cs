using System;
using Jurassic.Library;

public interface IStoreable
{
	void Move(int index, int targetIndex);

	ItemData GetInfo();

	bool Equals(IStoreable storeable);

	// Returns the int of how 
	int GetMaxStack();

	// Returns the js object version of the IStoreable object
	ObjectInstance GetJSObject();
}

