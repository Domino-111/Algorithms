using UnityEngine;
using System.Diagnostics;
using Random = UnityEngine.Random;
using System;

public class SearchTest : MonoBehaviour
{
    public int loopAmount = 5000;

    [ContextMenu("Run Search")]
    void Start()
    {
        int[] numbers = new int[50000];
        
        int target = 45000;

        Search search = new BruteForceSearch();

        for (int x = 0; x < numbers.Length; x++)
        {
            numbers[x] = Random.Range(0, numbers.Length);
        }

        numbers[Random.Range(0, numbers.Length)] = target;
        Array.Sort(numbers);

        // Linear Search
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        for (int x = 0; x < loopAmount; x++)
        {
            search.Find(numbers, target);
        }

        stopwatch.Stop();

        print(stopwatch.ElapsedMilliseconds);

        // Binary Search
        search = new BinarySearch();
        stopwatch = new Stopwatch();

        stopwatch.Start();

        for (int x = 0; x < loopAmount; x++)
        {
            search.Find(numbers, target);
        }

        stopwatch.Stop();

        print(stopwatch.ElapsedMilliseconds);
    }
}
