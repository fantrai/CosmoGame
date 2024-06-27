using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Matherial : MonoBehaviour, IMatherial
{
    float destroyRange = 0.5f;
    float flySpeed = 0.3f;

    [SerializeField] protected EnamMatherials matherial;

    EnamMatherials IMatherial.Matherial { get => matherial; set => matherial = value; }

    public void StartAnim(Transform target)
    {
        GetComponents<Collider2D>().ToList().ForEach(c => c.enabled = false);
        StartCoroutine(FlyToPlayer(target));
    }

    IEnumerator FlyToPlayer(Transform target)
    {
        do
        {
            transform.Translate((target.position - transform.position) * flySpeed);
            yield return new WaitForFixedUpdate();
        } while (Vector3.Distance(transform.position, target.position) > destroyRange);
        Destroy(gameObject);
    }
}
