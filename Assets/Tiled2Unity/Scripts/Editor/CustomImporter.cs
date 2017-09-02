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
		// add rigid body to Collision child
		var objs = prefab.GetComponentsInChildren<Transform>();
		foreach (var trans in objs) {
			if (trans.gameObject.name != "Collision") {
				continue;
			}
			var rigidbody2D = trans.gameObject.AddComponent<Rigidbody2D>();
			rigidbody2D.bodyType = RigidbodyType2D.Static;
			break;
		}
	}
}