using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public Renderer ground;
    public GameObject cheesePrefab;

    public Transform parentCheese;
    private Vector3 _groundSize;

    private List<Vector3> _listCheesePosSpawn = new();

    public int maxSpawn;
    private float _offsetPositionSpawn = 10;

    void Start()
    {
        _groundSize = ground.bounds.size;

        for (int i = 1; i <= maxSpawn; i++)
        {
            Vector3 areaPos = new((_groundSize.x - _offsetPositionSpawn) / 2, 0, (_groundSize.z - _offsetPositionSpawn) / 2);

            float posX = RandomSpawnerPos(-areaPos.x, areaPos.x);
            float posZ = RandomSpawnerPos(-areaPos.z, areaPos.z);

            Vector3 newSpawnPos = new Vector3(posX, 0.2f, posZ);

            _listCheesePosSpawn.Add(newSpawnPos);
            InstantiateCheese(newSpawnPos);
        }
    }

    private float RandomSpawnerPos(float min, float max)
    {
        return Random.Range(min, max);
    }

    private void InstantiateCheese(Vector3 cheesePos)
    {
        GameObject newCheese = Instantiate(cheesePrefab, cheesePos, Quaternion.identity, parentCheese);
    }
}
