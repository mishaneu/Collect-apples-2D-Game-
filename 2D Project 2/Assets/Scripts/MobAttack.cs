using UnityEngine;

public class MobAttack : MonoBehaviour
{
    public float attackCooldown = 2.0f;
    private float nextAttackTime = 0.0f;

    private Animator animator;
    private bool playerInRange;
    private MobMove mobMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        mobMovement = GetComponent<MobMove>();
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

    private void Update()
    {
        if (playerInRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void Attack()
    {
        mobMovement.canMove = false;
        animator.SetTrigger("Attack");
        Invoke("EndAttack", 1.0f);
    }

    private void EndAttack()
    {
        mobMovement.canMove = true;
    }
}
