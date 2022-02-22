using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathclip;
    public float jumpForce = 700f;

    private int jumpCount = 0; //���� ����Ƚ��
    private bool isGrounded = false;  //  �ٴڿ� ��Ҵ��� Ȯ��
    private bool isDead = false; //������¸� ��Ÿ��

    private Rigidbody2D playerRigdboody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ






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
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }




}
