using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapCreator : MonoBehaviour
{
    [SerializeField] List<AbstractPlanet> planets = new List<AbstractPlanet>();
    [SerializeField] List<float> distances = new List<float>();

    private void Start()
    {
        Destroy(this);
    }

    [ContextMenu("Пересоздание")]
    void ReCreate()
    {
        int child = transform.childCount - 1;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        float spawnDistance = 0;

        for (int i = 0; i < planets.Count; i++)
        {
            var pl = planets[i];
            if (pl != null)
            {
                int degree = Random.Range(0, 360);

                float x = spawnDistance * MathF.Cos(degree);
                float y = spawnDistance * MathF.Sin(degree);

                Vector2 spawnPos = new Vector3(x, y) + transform.position;

                Instantiate(pl.gameObject, spawnPos, pl.transform.rotation).transform.parent = transform;
                spawnDistance += pl.ControlRadius * 2;
            }
            spawnDistance += distances.Count - 1 < i ? distances.LastOrDefault() : distances[i];
        }
    }
}
