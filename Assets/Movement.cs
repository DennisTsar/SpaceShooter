using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float x;
    float z;
    public GameObject missile;
    public GameObject enemy;
    int r;
    // Start is called before the first frame update
    void Start()
    {
        x = 57;
        z = 20;
        r = 1;
        InvokeRepeating("Spawn",1,4);
    }

    // Update is called once per frame
    void Update()
    {
        float mov = 18 * Time.deltaTime;
        float rot = 25 * Time.deltaTime;
        float ang = transform.rotation.eulerAngles.z;
        if (ang > 300)
            ang -= 360;
        if (Input.GetKey(KeyCode.W) && transform.position.z < z)
            transform.Translate(Vector3.forward * mov, Space.World);
        if (Input.GetKey(KeyCode.S) && transform.position.z > -z)
            transform.Translate(Vector3.back * mov, Space.World);
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < x)
                transform.Translate(Vector3.right * mov, Space.World);
            if (ang < 45)
                transform.Rotate(Vector3.forward * rot);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -x)
                transform.Translate(Vector3.left * mov, Space.World);
            if (ang > -45)
                transform.Rotate(Vector3.back * rot);
        }
        else if (Mathf.Abs(ang) > 1.5f)
            transform.Rotate(Vector3.back * rot * Mathf.Sign(transform.rotation.z));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, new Vector3(transform.position.x + r * 4.14f, -.15f, transform.position.z + .5f),Quaternion.identity);
            r *= -1;
        }
    }
    public void Spawn()
    {
        Instantiate(enemy, new Vector3((int)(Random.Range(-x + 5, x - 5)/7)*8, 0, z + 15), Quaternion.Euler(0,180,0));
    }
}
