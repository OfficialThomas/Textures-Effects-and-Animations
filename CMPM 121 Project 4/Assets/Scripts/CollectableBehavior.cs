using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    public float _rotationSpeed = 1;
    public float _hoverSpeed = 1;
    public float _hoverDifference = 1;
    private bool _upwards = true;
    private Vector3 _origin;
    private GameObject _ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        _ScoreDisplay = GameObject.Find("Score");
        _origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);

        if (_upwards)
        {
            transform.position += Vector3.up * _hoverSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * _hoverSpeed * Time.deltaTime;
        }

        if(Mathf.Abs(transform.position.y - _origin.y) >= (_hoverDifference / 2))
        {
            _upwards = !_upwards;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _ScoreDisplay.GetComponent<ScoreBehavior>()._score += 1;
            Destroy(this.gameObject);
        }
    }
}
