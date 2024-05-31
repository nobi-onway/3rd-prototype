using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    private const float JUMP_FORCE = 700.0f;
    private bool _isOnGround = true;
    [SerializeField]
    private ParticleSystem _explosionParticle;
    [SerializeField]
    private ParticleSystem _dirtParticle;
    [SerializeField]
    private AudioClip _crashAudio;
    [SerializeField]
    private AudioClip _jumpAudio;
    private AudioSource _audioSource;
    public bool gameOver = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= 1.5f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _rb.AddForce(Vector3.up * JUMP_FORCE, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
            _dirtParticle.Stop();
            _audioSource.PlayOneShot(_jumpAudio);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _dirtParticle.Play();
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            _explosionParticle.Play();
            _dirtParticle.Stop();
            _audioSource.PlayOneShot(_crashAudio);
        }
    }
}
