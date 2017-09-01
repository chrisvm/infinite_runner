using System;
using UnityEngine;
using UnityEngine.WSA;

namespace Map {
	public class MapController : MonoBehaviour
	{
		public enum TileType : uint
		{
			Empty = 0,
			LeftPlatform = 1,
			MiddlePlatform = 2,
			RightPlatform = 3
		}

		private Sprite GetSpriteForTileType(TileType type)
		{
			switch (type) {
				case TileType.LeftPlatform:
					return LeftPlatformTile;
				case TileType.MiddlePlatform:
					return MiddlePlatformTile;
				case TileType.RightPlatform:
					return RightPlatformTile;
				default:
					return null;
			}
		}
		
		public Sprite LeftPlatformTile;
		public Sprite MiddlePlatformTile;
		public Sprite RightPlatformTile;
				
		private uint[] mapRepresentation = {
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 2, 3, 0, 0,
			0, 1, 2, 2, 3, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		};

		private const int mapWidth = 11;
		private GameObject boardHolder;

		void Start()
		{
			boardHolder = new GameObject();
			for (var index = 0; index < 3; index++) {
				var chunk = CreateMapChunk(mapRepresentation, new Vector2(index * mapWidth, 0));
				chunk.transform.SetParent(boardHolder.transform);
			}
		}
		
		GameObject CreateMapChunk(uint[] representation, Vector2 trans) 
		{
			// parent transform for the map
			var parent = new GameObject("Board");
			for (var index = 0; index < representation.Length; index += 1) {
				var tileType = (TileType) representation[index];
				if (tileType == TileType.Empty) continue;
				
				var tileSprite = GetSpriteForTileType(tileType);
				var xGrid = index % mapWidth * tileSprite.bounds.size.x;
				var yGrid = index / mapWidth * tileSprite.bounds.size.y;
				
				// create the gameobject to hold the created sprite renderer
				var gameObj = new GameObject();
				gameObj.transform.position = new Vector3(xGrid + trans.x, yGrid + trans.y, 0f);
				gameObj.transform.SetParent(parent.transform);
				
				// create the sprite to set to SpriteRenderer
				var sprite = Instantiate(tileSprite, new Vector3(), Quaternion.identity);
				var spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = sprite;
			}
			return parent;
		}
	}
}
