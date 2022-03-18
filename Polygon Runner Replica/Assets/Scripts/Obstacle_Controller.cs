using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

        if(transform.position.z <= -35f) {
            Destroy(gameObject);
        }
    }
}
