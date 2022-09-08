using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTDAs : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawn = new GameObject[5];
    [SerializeField] GameObject[] hostageSpawn = new GameObject[4];
    [SerializeField] GameObject[] BombSpawn = new GameObject[1];
    float alture = 0.5f;

    private void OnEnable()
    {
        Vector3 pos = transform.position;

        for (int i = 0; i < enemySpawn.Length; i++)
        {
            enemySpawn[i].transform.position = new Vector3(Random.Range(-19f, 14f), alture, Random.Range(-14, -4));
            enemySpawn[i].SetActive(true);
        }

        for (int i = 0; i < hostageSpawn.Length; i++)
        {
            hostageSpawn[i].transform.position = new Vector3(Random.Range(-19f, 14f), alture, Random.Range(-15f, 2.88f));
            hostageSpawn[i].SetActive(true);
        }

        for (int i = 0; i < BombSpawn.Length; i++)
        {
            BombSpawn[i].transform.position = new Vector3(Random.Range(-19f, 14f), alture, Random.Range(-15f, 2.88f));
            BombSpawn[i].SetActive(true);
        }
    }
}
