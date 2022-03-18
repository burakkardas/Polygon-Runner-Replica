using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

        if(transform.position.z <= -30f) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                30f
            );
        }
    }
}
