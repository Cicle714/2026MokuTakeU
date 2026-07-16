using UnityEngine;

public class EnemySowrd : MonoBehaviour
{
    Enemy enemy;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() && enemy.Attack)
        {
            if (!player.Guard)
            {
                player.hit = true;
                player.hp--;
                if (player.hp <= 0)
                {
                    player.anim.Play("HumanM@Death01");
                    enemy.anim.Play("smile");
                    enemy.move = false;
                }
                else
                    player.anim.Play("HumanM@CombatDamage01");
            }
            else
            {
                enemy.GetComponent<Animator>() .Play("repelled");
            }
        }
    }

}
