using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private GameObject _player;
    public float _rotateSpeed = 1;
    public Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime, Vector3.up) * _offset;
        transform.position = _player.transform.position + _offset;
        transform.LookAt(_player.transform.position);
    }
}
