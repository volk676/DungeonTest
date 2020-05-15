using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 movement;

    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float moveSpeed;
    public Weapon weapon;
    public Health healthObject;
    private float health = 3f;
    private bool invuln = false;
    private int invulnTimer = 50;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        doInvuln();

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Run_Right")
        {
            animator.SetBool("wasRight", true);
            animator.SetBool("wasLeft", false);
        }
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Run_Left")
        {
            animator.SetBool("wasRight", false);
            animator.SetBool("wasLeft", true);
        }
    }

    private void doInvuln()
    {
        if (invulnTimer == 0 && invuln)
        {
            invuln = false;
            invulnTimer = 50;
            spriteRenderer.enabled = true;
        }
        else if (invuln)
        {
            if (invulnTimer % 10 == 0)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }

            invulnTimer -= 1;
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (!invuln)
        {
            if (other.gameObject.tag == "Trap")
            {
                doHealth();
                invuln = true;
            }
        }

    }

    void doHealth()
    {
        health -= 0.5f;

        if (health == 0)
            SceneManager.LoadScene("Dungeon");

        int checkHealth = (int)health;

        if (health - checkHealth == 0.5)
        {
            healthObject.hearts[checkHealth].sprite = healthObject.heartSprites[1];
        }
        else
        {
            healthObject.hearts[checkHealth].sprite = healthObject.heartSprites[2];
        }
    }
}
