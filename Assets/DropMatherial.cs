using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMatherial : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField, Min(0)] int minCount = 0;
    [SerializeField, Min(0)] int maxCount = 0;

    public void Drop()
    {
        if (maxCount < minCount) Debug.LogWarning("Не правильно проставлены значения в объекте " + gameObject.name);
        int count = Random.Range(minCount, maxCount);
        for (int i = 0; i < count; i++)
        {
            Instantiate(item, transform.position, item.transform.rotation);
        }
    }
}
