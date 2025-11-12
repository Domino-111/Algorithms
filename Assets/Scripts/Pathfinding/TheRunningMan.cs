using MyPathfinding;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class TheRunningMan : MonoBehaviour
{
    public Dijkstra pathFinder, pathFinder2;
    public GridGenerator grid;

    [ContextMenu("Run Forest")]
    void Start()
    {
        // grid.GenerateGird();

        pathFinder.GetAllNodes();
        pathFinder2.GetAllNodes();

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
        int startNode = nodes.Length - 1;
        int goalNode = Random.Range(0, nodes.Length - 1);

        // Path Finder 1
        Stopwatch timer = new Stopwatch();
        timer.Start();
        List<Node> path = pathFinder.FindShortestPath(nodes[startNode], nodes[goalNode]);

        timer.Stop();
        pathFinder.DebugPath(path);
        Debug.Log("Pathfinder 1 = " + timer.ElapsedMilliseconds);

        // Path Finder 2

        timer = new Stopwatch();
        timer.Start();
        List<Node> path2 = pathFinder2.FindShortestPath(nodes[startNode], nodes[goalNode]);

        timer.Stop();
        pathFinder2.DebugPath(path2);
        Debug.Log("Pathfinder 2 = " + timer.ElapsedMilliseconds);
    }
}
