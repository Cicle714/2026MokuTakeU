using UnityEngine;

public class Sword : MonoBehaviour
{
    static public bool IsAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() && IsAttack)
        {
            other.gameObject.GetComponent<Enemy>().HitEnemy(1);
            IsAttack = false;
        }
    }

}
