using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool IsPush;
    private float PushCount;
    private float TapCount = 0.1f;
    private Animator anim;

    private Vector3 StartPos;
    private Vector3 EndPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPush)
        {
            PushCount += Time.deltaTime;
            EndPos = Mouse.current.position.ReadValue();

            if (Mathf.Abs(StartPos.magnitude - EndPos.magnitude) >= 300)
            {
                Sword.IsAttack = true;
                Debug.Log("çUåÇÅI");
                IsPush = false;
                anim.Play("HumanM@Attack1H01_R");
            }
        }
    }
    public void SlideAttack(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            IsPush = true;
            StartPos = Mouse.current.position.ReadValue();
        }


        if (context.canceled)
        {
            PushCount = 0;
            IsPush = false;
        }
    }
}
