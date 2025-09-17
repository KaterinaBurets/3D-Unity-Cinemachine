using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

public class CameraTriggerTimeLineHandler : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeLine;
    [SerializeField] private GameObject _character;
    [SerializeField] private CharacterController _controllerScript;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _placeStanding;
    private Animator _anim;
    private Animator _animHero;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _animHero = _character.GetComponent<Animator>();
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _character)
        {
            _controllerScript.enabled = false;
            _playerMovement.enabled = false;

            _character.transform.position = _placeStanding.transform.position;
            _character.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

            _timeLine.Play();

            await WaitOneSecondAsync();

            _animHero.SetBool("isIdle", true);

            _controllerScript.enabled = true;
            _playerMovement.enabled = true;

            GetComponent<CapsuleCollider>().isTrigger = false;
            _anim.SetBool("isRinoTalking", false);

        }
    }

    private async Task WaitOneSecondAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(27));
    }
}
