using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamCoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] GameObject RangeA;
    [SerializeField] GameObject RangeB;

    [SerializeField] int Spawn_num;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Spawn_num; ++i)
        {
            float x = Random.Range(RangeA.transform.position.x, RangeB.transform.position.x);
            float y = Random.Range(RangeA.transform.position.y, RangeB.transform.position.y);
            float z = Random.Range(RangeA.transform.position.z, RangeB.transform.position.z);

            Instantiate(CoinPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
