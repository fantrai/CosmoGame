using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class AbstractPlanet : MonoBehaviour, IPlanet
{
    public const int SPAWN_MOBS_PER_SECOND = 30;
    [SerializeField] CircleCollider2D controlZoneCollider;
    [SerializeField] AbstractEnemy[] enemyPrefabs;
    [SerializeField, Min(0)] float spawnRateMod = 1;

    Vector3 playerPos;

    Coroutine spawnCorutine;

    public float ControlRadius { get => controlZoneCollider.radius * transform.localScale.x; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(controlZoneCollider))
        {
            if (collision.gameObject.TryGetComponent(out IPlayer player))
            {
                IPlayer.OnMove += UpdatePlayerPos;
                spawnCorutine = StartCoroutine(SpawnMobs());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.IsTouching(controlZoneCollider))
        {
            if (collision.gameObject.TryGetComponent(out IPlayer player))
            {
                IPlayer.OnMove -= UpdatePlayerPos;
                StopCoroutine(spawnCorutine);
            }
        }
    }

    void UpdatePlayerPos(Vector3 pos)
    {
        playerPos = pos;
    }

    IEnumerator SpawnMobs()
    {
        do
        {
            if (spawnRateMod != 0)
            {
                yield return new WaitForSeconds(60 / (SPAWN_MOBS_PER_SECOND * spawnRateMod));
            }
            else
            {
                yield return new WaitForSeconds(1);
                continue;
            }
            float radScreen = Camera.main.orthographicSize * 2 * (Screen.width / Screen.height);

            var random = new System.Random();
            int degree = random.Next(0, 360);

            float x = radScreen * MathF.Cos(degree);
            float y = radScreen * MathF.Sin(degree);

            Vector2 spawnPos = new Vector3(x, y, 0) + playerPos;

            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)].gameObject;
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
        } while (true);
    }
}
