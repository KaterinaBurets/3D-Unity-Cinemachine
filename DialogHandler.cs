using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public async void TalkingToRino()
    {
        _text.text = "Тебя давно не было...";
        await WaitSecondsAsync();
        _text.text = "Да, я путешествовала давнольно долго, я измотана";
        await WaitSecondsAsync();
        _text.text = "Я восстановлю твои силы, возьми это яблоко";
        await WaitSecondsAsync();
        _text.text = "Без тебя я не смогла бы продолжить свое путешествие, спасибо тебе";
        await WaitSecondsAsync();
        _text.text = "";
    }

    private async Task WaitSecondsAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}
