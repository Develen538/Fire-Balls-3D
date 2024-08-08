using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delayBetweemShoots;
    [SerializeField] private float _recoil;

    private AudioSource _shootSound;

    private float _timeAfterShoot;

    private void Start()
    {
        _shootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweemShoots)
            {
                Shoot();
                _timeAfterShoot = 0;
                transform.DOMoveZ(transform.position.z - _recoil, _delayBetweemShoots / 2).SetLoops(2, LoopType.Yoyo);
                _shootSound.Play();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
    }
}
