using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private float _minX, _maxX;
    [SerializeField] private float _time;
    void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    IEnumerator Spawn() {
        while(true) {
            yield return new WaitForSeconds(_time);
            int _randomIndex = Random.Range(0, _obstacles.Length);
            GameObject _newObstacle = Instantiate(_obstacles[_randomIndex]);

            if(_randomIndex == 1) {
                _newObstacle.transform.position = new Vector3(
                    0,
                    transform.position.y,
                    transform.position.z
                );
            }
            else {
                _newObstacle.transform.position = new Vector3(
                Random.Range(_minX, _maxX),
                    transform.position.y,
                    transform.position.z
                );
            }
            
        }
    }
}
