using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Assertions;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        Assert.IsNotNull(_counter);
        Assert.IsNotNull(_textMeshPro);
    }

    private void OnEnable()
    {
        _counter.Changed += UpdateScore;
    }

    private void OnDisable()
    {
        _counter.Changed -= UpdateScore;
    }

    private void UpdateScore(int value)
    {
        _textMeshPro.text = $"{value}";
    }
}
