using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // for testing purposes
    public Transform MapChunk;
    public uint NewMapChunkDistance;

    private Transform _previousMapChunk;
    private uint _numberOfMapChunks;

    // Use this for initialization
    void Start()
    {
        _numberOfMapChunks++;        
        _previousMapChunk = Instantiate(GenerateMapChunk(), MapChunk.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberOfMapChunks < 5)
        {
            Vector3 newMapChunkPosition = new Vector3(_previousMapChunk.position.x + NewMapChunkDistance, _previousMapChunk.position.y);
            _previousMapChunk = GameObject.Instantiate(GenerateMapChunk(), newMapChunkPosition, Quaternion.identity);
            _numberOfMapChunks++;
        }
    }

    private Transform GenerateMapChunk()
    {
        return MapChunk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject.transform.parent.gameObject);
        _numberOfMapChunks--;
    }

}
