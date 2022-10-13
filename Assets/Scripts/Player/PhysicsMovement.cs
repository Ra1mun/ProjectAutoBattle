using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(KeyboardInput))]
public class PhysicsMovement : MonoBehaviour
{ 
    private Rigidbody _rigidbody;
    
    private float _speed;

    public void Init(float speed)
    {
        _speed = speed;
    }
    public void MoveDirection(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + (direction * _speed * Time.deltaTime));
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
