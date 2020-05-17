using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float startingZ = 330f;

    public float endingZ = 190;
    public float attackSpeed = -10f;

    private Animator animator;

    private Player player;

    private bool rightFacing = true;
    private bool leftFacing = false;

    private bool isAttacking = false;
    public SpriteRenderer spriteRenderer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ResetPos();
        animator = (Animator)this.GetComponentInParent(typeof(Animator));
    }

    private void setSide()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Right") && leftFacing)
        {
            startingZ = 330f;
            attackSpeed = -10f;
            endingZ = 190f;
            transform.localPosition = new Vector3(0.43f, -0.46f, 0);
            transform.localScale = new Vector3(1, 1, 1);
            rightFacing = true;
            leftFacing = false;
            ResetPos();
        }
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Left") && rightFacing)
        {
            startingZ = 30f;
            endingZ = 170f;
            attackSpeed = 10f;
            transform.localPosition = new Vector3(-0.3f, -0.46f, 0f);
            transform.localScale = new Vector3(-1, 1, 1);
            leftFacing = true;
            rightFacing = false;
            ResetPos();
        }
    }

    // Update is called once per frame
    void Update()
    {
        setSide();

        if (Input.GetKeyDown(KeyCode.X) && isAttacking == false)
            isAttacking = true;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (isAttacking)
        {
            var a = Mathf.Abs(transform.eulerAngles.z - endingZ);
            if (a >= 0 && a <= 2)
            {
                ResetPos();
                isAttacking = false;
            }
            else
            {
                moveWeapon(attackSpeed);
            }
        }

        
    }

    private void moveWeapon(float speed)
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + speed);
    }

    void ResetPos()
    {
        transform.rotation = Quaternion.Euler(0, 0, startingZ);
    }
}
