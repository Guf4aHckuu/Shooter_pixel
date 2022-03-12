using UnityEngine;

public class CameraView : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }
    private void FixedUpdate()
    {
        transform.position = _player.position + _offset;
    }
}
