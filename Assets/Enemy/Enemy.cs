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

    private float AttackDelay = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        AttackDelay = Random.Range(0.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            count += Time.deltaTime;
        }
        if (count > AttackDelay && HP > 0)
        {
            AttackDelay = Random.Range(1.0f, 2.5f);
            count = 0;
            anim.Play(null);
            anim.Play("root|slash01");
            Attack = true;
        }
        if (Attack)
        {
            AttackCount += Time.deltaTime;
            if(AttackCount > 1f)
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
            Attack = false;
            move = false;
            anim.Play("root|death");
        }
        else if(!Attack)
            anim.Play("root|Take Damage");
    }
}
