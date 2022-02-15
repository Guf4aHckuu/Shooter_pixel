using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 _movement;
    private PlayerMovement _playerMV;

    private void Awake()
    {
        _playerMV = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _movement = new Vector3(horizontal, vertical, 0f);
    }

    private void FixedUpdate()
    {
        _playerMV.MoveCharacter(_movement);
    }
}
