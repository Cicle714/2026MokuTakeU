using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameUI ui;

    [SerializeField]
    private Enemy enemy;
    public List<Enemy> enemys = new List<Enemy>();
    private Player player;

    [SerializeField]
    public int EnemyNum;

    public int BattleNum;

    public bool GameClear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = FindAnyObjectByType<GameUI>();
        player = FindObjectOfType<Player>();
        for (int i = 0; i <= EnemyNum; i++)
        {
            enemys.Add(Instantiate(enemy, player.transform.position + player.transform.forward * (i * 10) + player.transform.forward * 1.5f, player.transform.rotation * Quaternion.Euler(0, 180, 0)));

            enemys[i].GetComponent<Enemy>().MaxHP = i + 5;
            enemys[i].GetComponent<Enemy>().HP = i + 5;
        }
        enemys[BattleNum].move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameClear)
        if (enemys[BattleNum].GetComponent<Enemy>().HP <= 0)
        {
            ui.EnemyHP.gameObject.SetActive(false);
            BattleNum++;
            if(BattleNum >= enemys.Count)
            {
                GameClear = true;
            }else
                StartCoroutine(MoveIEnum(player.transform.position));
        }
    }

    public void PlayerMove(Vector3 pos) { StartCoroutine(MoveIEnum(pos)); }

    private IEnumerator MoveIEnum(Vector3 pos)
    {
        Vector3 StartPos = player.transform.position;
        player.anim.SetBool("Battle", false);
        float count = 0;
        yield return new WaitForSeconds(2f);
        player.anim.SetBool("Run", true);
        while (count <= 2)
        {
            count += Time.deltaTime;
            player.transform.position = Vector3.Lerp(StartPos, enemys[BattleNum].transform.position + enemys[BattleNum].transform.forward * 1.75f, count / 2);
            yield return null;
        }

        ui.EnemyHP.gameObject.SetActive(true);
        player.anim.SetBool("Battle", true);
        player.anim.SetBool("Run", false);
        enemys[BattleNum].move = true;
    }

}
