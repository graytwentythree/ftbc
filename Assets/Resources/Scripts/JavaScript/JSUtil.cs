using System;
using Jurassic;
using Jurassic.Library;

namespace JSUtil
{
	public class JSVectorConstructor : ClrFunction
	{
		public JSVectorConstructor(ScriptEngine engine)
			: base(engine.Function.InstancePrototype, "Vector", new JSVectorInstance(engine.Object.InstancePrototype))
		{ }

		//The JSConstructorFunction attribute marks the method that is called when the new operator is used to create an instance in a JavaScript
		[JSConstructorFunction]
		public JSVectorInstance Construct(double x, double y, double z)
		{
			return new JSVectorInstance(this.InstancePrototype, x, y, z);
		}
	}

	//This is the instance class for the JS Vector class.
	public class JSVectorInstance : ObjectInstance
	{
		public JSVectorInstance(ObjectInstance prototype)
			: base(prototype)
		{
			this.PopulateFunctions();
		}

		public JSVectorInstance(ObjectInstance prototype, double x, double y, double z) : base(prototype)
		{
			this.SetPropertyValue("x", x, true);
			this.SetPropertyValue("y", y, true);
			this.SetPropertyValue("z", z, true);
		}

		[JSFunction]
		public void Reset()
		{
			this.SetPropertyValue("x", 0, true);
			this.SetPropertyValue("y", 0, true);
			this.SetPropertyValue("z", 0, true);
		}
	}
}

