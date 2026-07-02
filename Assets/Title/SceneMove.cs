using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScreenTouch(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("MainGame");
    }
}
