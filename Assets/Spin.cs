using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 100;
    public float time = 0;

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        time += Time.deltaTime;

        float x = 6 * Mathf.Cos(time);
        float y = 0;
        float z = 3 * Mathf.Sin(time);
        transform.position = new Vector3(x, y, z);
    }
}
