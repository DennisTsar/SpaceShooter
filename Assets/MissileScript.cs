using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*10,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 10*Time.deltaTime);
        if (transform.position.z > 35)
            Destroy(this.gameObject);
    }
}
