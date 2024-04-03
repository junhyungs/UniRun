using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip Death;

    private Rigidbody2D PlayerRigid;
    private Animator PlayerAnimator;
    private AudioSource PlayerAudio;

    private int JumpCount = 0;
    private bool IsGround = false;
    private bool IsDead = false;

    [SerializeField]
    private float JumpForce = 700.0f;

    private void Awake()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();  
        PlayerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsDead)
            return;

        bool IsJump = Input.GetMouseButtonDown(0) && JumpCount < 2;
        if (IsJump)
        {
            JumpCount++;
            PlayerRigid.velocity = Vector2.zero;
            PlayerRigid.AddForce(new Vector2(0, JumpForce));
            PlayerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && PlayerRigid.velocity.y > 0)
        {
            PlayerRigid.velocity *= 0.5f;
        }
        PlayerAnimator.SetBool("Ground", IsGround);
    }

    private void Die()
    {
        PlayerAnimator.SetTrigger("Die");
        PlayerAudio.clip = Death;
        PlayerAudio.Play();
        PlayerRigid.velocity = Vector2.zero;

        IsDead = true;
        GameManager.Instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && !IsDead)
            Die();
        if (collision.CompareTag("Coin") && !IsDead)
        {
            GameManager.Instance.AddCoinScore(10);
            collision.gameObject.SetActive(false);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            IsGround = true;
            JumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGround = false;
    }
}
