using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyStatus
{
    private Animator anim;
    [SerializeField]
    private List<AnimatorOverrideController> anims;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HitEnemy(int PlayerAttack)
    {
        HP -= PlayerAttack;
        anim.SetTrigger("take damage");
        if (HP <= 0)
        {
            anim.runtimeAnimatorController = anims[1];
            //Destroy(gameObject);
        }
    }
}
