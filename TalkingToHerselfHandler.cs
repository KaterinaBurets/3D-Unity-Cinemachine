using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TalkingToHerselfHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioSource _tths1;
    [SerializeField] private AudioSource _tths2;
    [SerializeField] private AudioSource _tths3;
    [SerializeField] private AudioSource _tths4;

    async void Start()
    {
        await WaitSecondsAsync();
        _tths1.Play();
        _text.text = "Где это я?";
        await WaitSecondsAsync();
        _text.text = "";
        await WaitSecondsAsync();

        _tths2.Play();
        _text.text = "Мне нужно срочно поправить здоровье.";
        await WaitSecondsAsync();
        _text.text = "";
        await WaitSecondsAsync();

        _tths3.Play();
        _text.text = "На деревьях растут целебные яблоки.";
        await WaitSecondsAsync();
        _text.text = "";
        await WaitSecondsAsync();

        _tths4.Play();
        _text.text = "Где хоть одно дерево? Я вижу только цветы.";
        await WaitSecondsAsync();
        _text.text = "";
        await WaitSecondsAsync();
    }

    private async Task WaitSecondsAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
    }
}
