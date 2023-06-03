using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMocos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestuirMocos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DestuirMocos()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }

}
