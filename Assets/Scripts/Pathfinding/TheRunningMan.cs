using MyPathfinding;
using System.Collections.Generic;
using UnityEngine;


public class TheRunningMan : MonoBehaviour
{
    public Dijkstra pathFinder;
    public GridGenerator grid;

[ContextMenu("Run Forest")]
    void Start()
    {
        // grid.GenerateGird();

        pathFinder.GetAllNodes();

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
        int startNode = nodes.Length - 1;
        int goalNode = Random.Range(0, nodes.Length - 1);

        List<Node> path = pathFinder.FindShortestPath(nodes[startNode], nodes[goalNode]);
        pathFinder.DebugPath(path);
    }
}
