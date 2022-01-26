using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public GameObject explosion;
    public GameObject missile;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 9)
            transform.Translate(Vector3.forward*Time.deltaTime*5);
        else if (time < 12)
            transform.Translate(new Vector3(1, 0, -1)*Time.deltaTime*5);
        else
            transform.Translate(new Vector3(2, 0, 1) * Time.deltaTime*5);
        if (transform.position.x < -65)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity),2);
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
