using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 movement;

    public Rigidbody2D rb;

    public Animator animator;

    public float moveSpeed;
    public Weapon weapon;
    public Health healthObject;
    private float health = 1f;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
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
    
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            health -= 0.5f;

            switch(health)
            {
                case 0.5f:
                    healthObject.spriteRenderer.sprite = healthObject.hearts[1];
                    break;
                case 0f:
                    healthObject.spriteRenderer.sprite = healthObject.hearts[2];
                    SceneManager.LoadScene("Dungeon");
                    break;
            }
        }
    }
}
