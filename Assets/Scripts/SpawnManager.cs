using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] fishPrefabs;
    [SerializeField] BoxCollider2D boundaryCollider;
    private int _numberOfObjects = 10;
    private int _maxAttempts = 10;

    void Start()
    {
        InstantiateObjects();
    }

    void InstantiateObjects()
    {
        List<Vector2> validPositions = new List<Vector2>();


        for (int i = 0; i < _numberOfObjects; i++)
        {
            Vector2 randomPosition = GenerateRandomPosition();
            validPositions.Add(randomPosition);
        }
        
        foreach (Vector2 position in validPositions)
        {
            int randomIndex = UnityEngine.Random.Range(0, fishPrefabs.Length);
            Instantiate(fishPrefabs[randomIndex], position, Quaternion.identity);
        }
    }

    Vector2 GenerateRandomPosition()
    {
        Vector2 randomPoint = Vector2.zero;
        int attempts = 0;

        while (attempts < _maxAttempts)
        {
            randomPoint = new Vector2(
                UnityEngine.Random.Range(boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x),
                UnityEngine.Random.Range(boundaryCollider.bounds.min.y, boundaryCollider.bounds.max.y)
            );

            if (IsPointWithinBoundary(randomPoint))
            {
                return randomPoint;
            }

            attempts++;
        }

        Debug.LogWarning("Failed to find a valid position within the boundary after " + _maxAttempts + " attempts.");
        return randomPoint;
    }

    bool IsPointWithinBoundary(Vector2 point)
    {
        // Check if the point is within the boundary
        return boundaryCollider.OverlapPoint(point);
    }
}
