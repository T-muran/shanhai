using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    private float spawnCounter;

    public Transform minSpawn, maxSpawn;

    private Transform target;
    void Start()
    {
        spawnCounter = timeToSpawn;

        target = PlayerHealthController.instance.transform;
    }

    void Update()
    {
        if (GameController.GetInstance().StateMachine.GetCurrentState().ToString().Equals("PlayState"))
        {
            spawnCounter -= Time.deltaTime;
            //如果玩家死亡，不再生成敌人
            if (spawnCounter <= 0 && PlayerHealthController.instance.currentHp > 0)
            {
                spawnCounter = timeToSpawn;

                Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
            }
            transform.position = target.position;
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }



        return spawnPoint;
    }
}
