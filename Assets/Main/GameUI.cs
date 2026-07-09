using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    GameManager gameManager;
    Player player;

    [SerializeField]
    private Slider PlayerHP;
    public Slider EnemyHP;
    [SerializeField]
    Image Black;
    private float BlackCount;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP.value = (float)(player.hp) / (float)(player.maxHp);
        EnemyHP.value = (float)(gameManager.enemys[gameManager.BattleNum].GetComponent<Enemy>().HP)/ (float)(gameManager.enemys[gameManager.BattleNum].GetComponent<Enemy>().MaxHP);
        if(player.hp <= 0)
        {
            if(Black.color.a < 1)
            {
                BlackCount += Time.deltaTime / 3;
                Black.color = new Color(0, 0, 0, BlackCount);
            }else
                SceneManager.LoadScene("Title");
        }
    }


}
