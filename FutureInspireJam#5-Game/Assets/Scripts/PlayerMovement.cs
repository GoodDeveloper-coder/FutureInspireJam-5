using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask _groundLayerMask;
    private Rigidbody _rb;
    private bool _isOnGround = false;
    private bool _canMove = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        if (!_canMove)
           return;

        Move();
        CheckGround();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Move()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * _speed;
        moveDirection.y = _rb.velocity.y;
        _rb.velocity = moveDirection;
    }

    void Jump()
    {
        if (_isOnGround)
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    
    void CheckGround()
    {
        _isOnGround =  Physics.CheckSphere(transform.position + new Vector3(0, -1f, 0), 0.15f, _groundLayerMask);
    }

    public void SetCanMove(bool canMove)
    {   
        _canMove = canMove;
        _rb.velocity = Vector3.zero;
    }
}
