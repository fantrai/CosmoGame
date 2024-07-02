using System;
using UnityEngine;

public class DropMatherial : MonoBehaviour
{
    const float RAND_SPAWN_RADIUS = 1.5f;

    public static float ModCount { get; set; } = 1;
    public static float ModChanceDrop { get; set; } = 1;

    [SerializeField] GameObject item;
    [SerializeField, Min(0)] int minCount = 0;
    [SerializeField, Min(0)] int maxCount = 0;
    [SerializeField, Range(0, 100)] float chanceDrop = 100;

    public void Drop()
    {
        if (maxCount < minCount) Debug.LogWarning("Не правильно проставлены значения в объекте " + gameObject.name);
        int count = Mathf.CeilToInt(UnityEngine.Random.Range(minCount * ModCount, maxCount * ModCount));
        if (UnityEngine.Random.Range(0f, 100f) <= chanceDrop * ModChanceDrop)
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(item, (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * RAND_SPAWN_RADIUS, item.transform.rotation);
            }
        }
    }
}
