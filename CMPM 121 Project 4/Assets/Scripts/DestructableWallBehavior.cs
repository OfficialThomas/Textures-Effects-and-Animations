using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWallBehavior : MonoBehaviour
{
    public float _sizeDiff = 0.5f;
    private Vector3 _originalSize;
    // Start is called before the first frame update
    void Start()
    {
        _originalSize = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        float comparisonX = Mathf.Abs(_originalSize.x - transform.localScale.x) / _originalSize.x;
        float comparisonY = Mathf.Abs(_originalSize.y - transform.localScale.y) / _originalSize.y;
        float comparisonZ = Mathf.Abs(_originalSize.z - transform.localScale.z) / _originalSize.z;
        if (comparisonX >= _sizeDiff || comparisonY >= _sizeDiff || comparisonZ >= _sizeDiff)
        {
            Destroy(this.gameObject);
        }
    }
}
