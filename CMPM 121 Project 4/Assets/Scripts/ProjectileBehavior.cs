using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _speed = 1;
    public float _maxTimer = 5;
    private float _startTime;
    private GameObject _ScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        _ScoreDisplay = GameObject.Find("Score");
        _rigidbody = GetComponent<Rigidbody>();
        _startTime = Time.time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        if (Time.time - _startTime >= _maxTimer)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (!other.gameObject.CompareTag("Collectable"))
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    _ScoreDisplay.GetComponent<ScoreBehavior>()._score += 1;
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);

            }
        }  
        
    }

}
