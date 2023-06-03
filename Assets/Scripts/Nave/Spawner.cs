using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] Prefabs;

    [SerializeField] private float secondsSpawn = 0.3f;

    [SerializeField] private float minTras;

    [SerializeField] private float maxTras;

    [SerializeField] private float Segundos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects()); 
        StartCoroutine("Destruir");
    }

    private IEnumerator SpawnObjects()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondsSpawn);
        }
    }
    private IEnumerator Destruir()
    {
        yield return new WaitForSeconds(Segundos);
        Destroy(this.gameObject);
    }
}
