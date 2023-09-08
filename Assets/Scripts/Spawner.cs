using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float minHeight = -1f;

    [SerializeField]
    private float maxHeight = 2f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void Spawn()
    {
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
        obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
