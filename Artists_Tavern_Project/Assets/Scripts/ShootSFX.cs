using UnityEngine;

public class ShootSFX : AudioPlayer
{
    [SerializeField] WeaponBehaviour _w = null;

    private void OnEnable()
    {
        _w.OnShoot += _w_OnShoot;
    }

    private void OnDisable()
    {
        _w.OnShoot -= _w_OnShoot;
    }

    private void _w_OnShoot(WeaponBehaviour arg0)
    {
        Play();
    }
}
