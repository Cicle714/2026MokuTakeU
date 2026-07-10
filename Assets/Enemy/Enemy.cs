using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyStatus
{
    public Animator anim;
    [SerializeField]
    private List<AnimatorOverrideController> anims;

    public bool move = false;

    private float count = 0;
    public bool Attack = false;
    private float AttackCount = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 2 && HP > 0 && move)
        {
            count = 0;
            anim.Play("root|slash01");
            Attack = true;
        }
        if (Attack)
        {
            AttackCount += Time.deltaTime;
            if(AttackCount > 0.5f)
            {
                AttackCount = 0;
                Attack = false;
            }
        }
    }
    public void HitEnemy(int PlayerAttack)
    {
        HP -= PlayerAttack;
        if (HP <= 0)
        {
            move = false;
            anim.Play("root|death");
        }
        else if(!Attack)
            anim.Play("root|Take Damage");
    }
}
