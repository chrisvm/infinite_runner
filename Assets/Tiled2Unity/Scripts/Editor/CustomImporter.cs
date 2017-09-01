using System.Collections.Generic;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class CustomImporterAddComponent : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> props)
	{
		var chunkProperties = gameObject.AddComponent<Map.MapChunkProperties>();
		chunkProperties.EndPoints = props["EndPoints"];
	}


	public void CustomizePrefab(GameObject prefab)
	{
		// Do nothing
	}
}