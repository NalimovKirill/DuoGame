using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.WSA;

public class BallMover : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    public Vector2 _direction;
    public Vector2 _startPosition;
    [SerializeField] private float _speed = 8;
    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;

        Invoke("Launch", 2f);
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        _rigidBody2D.velocity = new Vector2(_speed * x, _speed * y);
    }

    public void Reset()
    {
        _rigidBody2D.velocity = Vector2.zero;
        transform.position = _startPosition;

        Invoke("Launch", 2f);
    }

}
