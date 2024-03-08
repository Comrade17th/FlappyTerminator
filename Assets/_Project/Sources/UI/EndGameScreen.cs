using UnityEngine;
using System;
using TMPro;
using UnityEngine.Assertions;

public class EndGameScreen : Window
{
    [SerializeField] private TextMeshProUGUI _score;
    
    public event Action RestartButtonClicked;

    private void Awake()
    {
        Assert.IsNotNull(_score);
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }
    
    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public void UpdateScore(int score)
    {
        _score.text = $"YOUR SCORE\n{score}";
    }
    
    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
