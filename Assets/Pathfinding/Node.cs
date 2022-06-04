using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node 
{
    public Vector2Int coordinates;
    public bool isWalkable; // if node can be added to tree
    public bool isExplored; // if the node has been explored
    public bool isPath; // if the node is in the path
    public Node connectedTo;

    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
