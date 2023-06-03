using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //seguramente se pueda hacer que segun el nivel se cambien lso valores, aprovechando la variable static de los niveles que tiene PlayerFollow
    [SerializeField] GameObject[] Prefabs;

    [SerializeField] private float secondsSpawn = 0.3f;

    [SerializeField] private float minTras;

    [SerializeField] private float maxTras;

    [SerializeField] private float Segundos;

    void Start()
    {
        StartCoroutine(SpawnObjects()); 
        StartCoroutine(Destruir());
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
