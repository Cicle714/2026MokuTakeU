using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    void Awake()
    {
    }

    void Start()
    {
    }
    public void ScreenTouch(InputAction.CallbackContext context)
    {
        if (context.canceled)
            SceneManager.LoadScene("MainGame");
    }
}
