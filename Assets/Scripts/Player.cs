using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    private float moveForce = 10f;
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer sr;

    private bool isGrounded;
    private string BLADE_TAG = "Blade";
    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
        AnimatePlayer();
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool("Walk", true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(BLADE_TAG))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        if (collision.gameObject.CompareTag("Void"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        if (collision.gameObject.CompareTag("Goal1"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LevelTwo");
        }
    }

}
