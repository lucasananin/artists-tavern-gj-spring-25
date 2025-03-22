using UnityEngine;

public class MuzzleFlashVFX : MonoBehaviour
{
    [SerializeField] WeaponBehaviour _weapon = null;
    [SerializeField] ParticleSystem _particle = null;

    private void Awake()
    {
        _weapon = GetComponentInParent<WeaponBehaviour>();
        _particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        _weapon.OnShoot += Play;
    }

    private void OnDisable()
    {
        _weapon.OnShoot -= Play;
    }

    private void Play(WeaponBehaviour arg0)
    {
        _particle.Play();
    }
}
