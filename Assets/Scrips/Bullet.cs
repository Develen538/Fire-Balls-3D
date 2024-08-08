using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _Force;
    [SerializeField] private float _distants;
    [SerializeField] private Tank _tank;

    private AudioSource _bounce;

    private Vector3 _moveDirection;

    private void Start()
    {
        _bounce = GetComponent<AudioSource>();
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }

        if (other.TryGetComponent(out ObstaticlDamage obstaicl))
        {
            _bounce.Play();
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_Force,transform.position + new Vector3(0,-1,1),_distants);

    }
}
