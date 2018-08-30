using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    private Transform[] spawnpoints;
    
    private void Awake()
    {
        Instance = this;
        spawnpoints = GetComponentsInChildren<Transform>();
    }

    public Vector3 GetPlayerStartPos(int index)
    {
        return spawnpoints[index].position;
    }

    public Vector3 GetPlayerSpawnPos()
    {
        var index = Random.Range(0, GameManager.Instance.Players.Count);
        return spawnpoints[index].position;
    }
}
