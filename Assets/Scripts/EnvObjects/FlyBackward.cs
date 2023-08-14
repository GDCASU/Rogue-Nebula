using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBackward : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
