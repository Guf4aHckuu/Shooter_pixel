using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _playerRB;
    private Animator _animator;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetInteger("Run", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetInteger("Run", 2);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _animator.SetInteger("Run", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger("Run", 4);
        }
        else
        {
            _animator.SetInteger("Run", 0);
        }
    }

    public void MoveCharacter(Vector3 movement)
    {
        _playerRB.velocity = movement * _speed;
    }

}
