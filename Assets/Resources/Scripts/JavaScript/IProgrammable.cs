using System;

public interface IProgrammable
{
	// Calls tick function in specified JS code every frame.
	void Tick();

	// Creates an object instance in javascript containing the a JS API.
	void RefreshJSObject(string path);
}

