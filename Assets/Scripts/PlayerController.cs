using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 5f; 
    public float ShrinkSpeed = 1f;
    public float MaxRotationSpeed = 200f;
    
    public GameObject WinPanel;

        
    private bool _isGrounded;
    private bool _isCanControll = true;
    private bool _isShrinking;
    private AudioSource _collisionSound;
    
    private Rigidbody2D _rb;    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collisionSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, -MaxRotationSpeed, MaxRotationSpeed);
        if (_isShrinking)
        {
            Shrink();
        }
        
        if (_isCanControll)
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, _rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
            { 
                _rb.velocity = new Vector2(_rb.velocity.x, JumpHeight);
            }
        }

        if (!gameObject.activeSelf)
        {
            WinPanel.SetActive(true);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            _isCanControll = false;
        }
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _collisionSound.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    
    public void StartShrinking()
    {
        _isShrinking = true;
    }
    
   
    
    void Shrink()
    {
        transform.localScale -= new Vector3(ShrinkSpeed, ShrinkSpeed, 0) * Time.deltaTime;

        if (transform.localScale.x <= 0 || transform.localScale.y <= 0)
        {
            _isShrinking = false;
            gameObject.SetActive(false); 
        }
    }
}
