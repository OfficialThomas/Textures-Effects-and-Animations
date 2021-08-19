using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    public Text _scoreDisplay;
    public int _score;

    // Start is called before the first frame update
    void Start()
    {
        _scoreDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreDisplay.text = "Score: " + _score;
    }
}
