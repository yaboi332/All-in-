using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
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
    
    
}
