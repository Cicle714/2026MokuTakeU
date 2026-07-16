using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    GameManager gameManager;

    private bool IsPush;
    private float PushCount;
    private float TapCount = 0.1f;
    public Animator anim;

    private Vector3 StartPos;
    private Vector3 EndPos;

    public bool Guard;
    private float GuardCount;
    private bool GuardDelay;
    private float GuardDelayCount;

    public int maxHp;
    public int hp;

    public bool hit;
    private float HitDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) return;

        if (hit)
        {
            HitDelay += Time.deltaTime;
            if (HitDelay >= 0.5)
            {
                hit = false;
                HitDelay = 0;
            }
            return;
        }


        Debug.Log(Mathf.Abs(StartPos.magnitude - EndPos.magnitude));
        if (IsPush)
        {
            PushCount += Time.deltaTime;
            EndPos = Touchscreen.current.position.ReadValue();

            float distance = Vector2.Distance(StartPos, EndPos);

            if (distance >= 100f)
            {
                Debug.Log("UŒ‚I");
                IsPush = false;

                anim.Play(null);
                anim.Play("HumanM@Attack1H01_R");
                Sword.IsAttack = true;

                if (Guard)
                {
                    GuardCount = 0;
                    Guard = false;
                    GuardDelay = true;
                }
            }
        }


        if (Guard)
        {
            GuardCount += Time.deltaTime;
            if(GuardCount > 0.75f)
            {
                GuardCount = 0;
                Guard = false;
                GuardDelay = true;
            }
        }
        if (GuardDelay)
        {
            GuardDelayCount += Time.deltaTime;
            if(GuardDelayCount > 0.5f)
            {
                GuardDelayCount = 0;
                GuardDelay = false;
            }
        }

    }
    public void SlideAttack(InputAction.CallbackContext context)
    {
        if (!anim.GetBool("Run") && hp > 0)
        {
            if (context.started)
            {
                IsPush = true;
                StartPos = Touchscreen.current.position.ReadValue();
            }


            if (context.canceled)
            {
                if (IsPush && !GuardDelay && !Guard && !hit)
                {
                    Guard = true;
                    anim.Play("Guard");
                }
                PushCount = 0;
                IsPush = false;
            }
        }
    }
}
