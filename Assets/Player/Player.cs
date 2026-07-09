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
        Debug.Log(Mathf.Abs(StartPos.magnitude - EndPos.magnitude));
        if (IsPush)
        {
            PushCount += Time.deltaTime;
            EndPos = Pointer.current.position.ReadValue();

            float distance = Vector2.Distance(StartPos, EndPos);

            if (distance >= 100f)
            {
                Sword.IsAttack = true;
                Debug.Log("UŒ‚I");
                IsPush = false;
                anim.Play("HumanM@Attack1H01_R");
            }
        }


        if (Guard)
        {
            GuardCount += Time.deltaTime;
            if(GuardCount > 0.5f)
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
                StartPos = Pointer.current.position.ReadValue();
            }


            if (context.canceled)
            {
                if (IsPush && !GuardDelay && !Guard)
                {
                    Guard = true;
                    anim.Play("HumanM@Attack1H01_L 0");
                }
                PushCount = 0;
                IsPush = false;
            }
        }
    }
}
