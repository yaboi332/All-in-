using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }
    
    public void Attack(EnemyAnimations enemyAnimations)
    {
        anim.SetBool("isAttacking", true);
        enemyAnimations.Hurt();
    
    }

    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    
    }
    
    
}
