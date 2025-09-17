using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] private Image _heathBarImage;
    public void HeathBarIsFilled()
    {
        _heathBarImage.fillAmount = 1f;
    }

}
