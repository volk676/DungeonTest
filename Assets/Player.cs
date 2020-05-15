using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 movement;

    public Rigidbody2D rb;

    public Animator animator;

    public float moveSpeed;
    public bool rightFacing = true;
    public bool leftFacing = false;

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
            rightFacing = true;
            leftFacing = false;
        }
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Run_Left")
        {
            animator.SetBool("wasRight", false);
            animator.SetBool("wasLeft", true);
            rightFacing = true;
            leftFacing = false;
        }
    }
}
