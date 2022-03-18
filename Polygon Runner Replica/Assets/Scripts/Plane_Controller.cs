using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plane_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _xLimit;

    private void Start() {
        StartCoroutine(nameof(UpdateScore));
    }

    void Update()
    {
        _scoreText.text = _score.ToString();

        float _horizontal = 0;
        float _newX = 0;

        if(Input.GetMouseButton(0)) {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }

        
        if(_horizontal > 0) {
            UpdateRotation(-20f);
        }
        else if(_horizontal < 0) {
            UpdateRotation(20f);
        }
        else {
            UpdateRotation(0f);
        }
        

        _newX = transform.position.x + _horizontal * _xSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_xLimit, _xLimit);

        transform.position = new Vector3(
            _newX,
            transform.position.y,
            transform.position.z
        );
    }

    private void UpdateRotation(float _value) {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, _value), 5 * Time.deltaTime);
    }

    IEnumerator UpdateScore() {
        while(true) {
            yield return new WaitForSeconds(1);
            _score++;
        }
    }
}
