using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private int _health;
    [SerializeField] private Text _healthText;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove;
    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _died;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_died)
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal");

            _rigidbody2D.velocity = new Vector2(_horizontalMove * _speed, _rigidbody2D.velocity.y);

            if (!_facingRight && _horizontalMove > 0)
            {
                Flip();
            }
            else if (_facingRight && _horizontalMove < 0)
            {
                Flip();
            }

            if (_horizontalMove == 0)
            {
                _animator.SetBool("Walk", false);
            }
            else
            {
                _animator.SetBool("Walk", true);
            }
        }
    }

    private void Update()
    {
        if (!_died)
        {
            _healthText.text = "HP: " + _health.ToString();

            if (_health <= 0)
            {
                _animator.SetTrigger("Died");
                Invoke(nameof(ResetScene), 2f);
                _died = true;
            }

            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = Vector2.up * _jumpForce;
            }

            if (_isGrounded)
            {
                _animator.SetBool("Jump", false);
            }
            else
            {
                _animator.SetBool("Jump", true);
            }
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage(int damage)
    {
        if (!_died)
        {
            _health -= damage;
            _animator.SetTrigger("Damage");
        }
    }

    public void SizeCollider()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(1.492382f, 0.229647f);
        boxCollider2D.offset = new Vector2(-0.003047407f, -0.06369022f);
    }

    void Flip()
    {
        if (!_died)
        {
            _facingRight = !_facingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}