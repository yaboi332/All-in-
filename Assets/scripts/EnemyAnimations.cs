using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }
    
    public void Attack()
    {
        anim.SetBool("isAttacking", true);
    
    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    
    }

    public void Dead()
    {
        anim.SetBool("isDead", true);
    
    }
}