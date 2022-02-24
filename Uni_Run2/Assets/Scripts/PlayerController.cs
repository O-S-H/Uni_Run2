using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathclip;
    public float jumpForce = 700f;

    private int jumpCount = 0; //누적 점프횟수
    private bool isGrounded = false;  //  바닥에 닿았는지 확인
    private bool isDead = false; //사망상태를 나타탬

    private Rigidbody2D playerRigdboody; // 사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트






    // Start is called before the first frame update
    private void Start()
    {
        playerRigdboody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigdboody.velocity = Vector2.zero;

            playerRigdboody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigdboody.velocity.y > 0)
        {
            playerRigdboody.velocity = playerRigdboody.velocity * 0.5f;



        }
        animator.SetBool("Grounded", isGrounded);



    }
    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathclip;
        playerAudio.Play();

        playerRigdboody.velocity = Vector2.zero;
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        isGrounded = false;
    }




}
