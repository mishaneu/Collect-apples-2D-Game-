using UnityEngine;
using System.Collections;

public class MobBeh : MonoBehaviour
{
    public float attackCooldown = 2.0f;
    private float nextAttackTime = 0.0f;

    private Animator animator;
    private bool playerInRange;

    public float speed = 1.3f;
    public float leftLimit = -2.7f;
    public float rightLimit = -0.2f;
    private bool canMove = true;
    private bool movingLeft = true;
    private bool isRotate = false;

    private Player pos;

    void Start()
    {
        pos = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Time.time >= nextAttackTime)
        {
            if (movingLeft && !pos.facingRight)
            {
                Flip();
                isRotate = true;
            }

            StartCoroutine(HandleAttackAndFlip());
            nextAttackTime = Time.time + attackCooldown; 
        }

        if (canMove)
        {
            Move();
        }
    }

    private void Attack()
    {
        canMove = false;
        animator.SetTrigger("Attack");
    }

    private void EndAttack()
    {
        canMove = true;
    }

    private void Move()
    {
        if (movingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= leftLimit)
            {
                movingLeft = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= rightLimit)
            {
                movingLeft = true;
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private IEnumerator HandleAttackAndFlip()
    {
        Attack();
        yield return new WaitForSeconds(1.5f);
        if (isRotate)
        {
            Flip();
            isRotate = false;
        }

        EndAttack(); 
    }
}
