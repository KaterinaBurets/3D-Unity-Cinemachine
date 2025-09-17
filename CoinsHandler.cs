using UnityEngine;
using TMPro;

public class CoinsHandler : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private TextMeshProUGUI _coinsBar;
    [SerializeField] private AudioSource _coinSound;

    private void Update()
    {
        _coinsBar.text = _coins.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _coins++;
            _coinSound.Play();
            Destroy(other.gameObject);
        }
    }
}
