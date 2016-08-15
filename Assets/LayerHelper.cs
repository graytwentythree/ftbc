public class LayerHelper
{
	public const string ACTOR_LAYER = "actor";
	public const string BLOCK_LAYER = "block";
	public const string ENTITY_LAYER = "entity";

	public static int LayerToLayerMask(int layer)
	{
		return 1 << layer;
	}

	public static int LayerMaskToLayer(int layer)
	{
		return 1 >> layer;
	}
}

