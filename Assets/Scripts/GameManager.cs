using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameData")]
    public bool isStart = false;
    public int score;
    public Text text_score;
    public GameObject Btn_GameStart;

    [Header("PlayerData")]
    public GameObject Player;
    public float playerFlyForce;

    [Header("Objects")]
    public float createTime;
    public float createDelay;
    public GameObject[] Boxes;
    public Transform Panel_Boxes;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart == true)
        {
            createTime += Time.deltaTime;

            if(createTime >= createDelay)
            {
                int rand_box = Random.Range(0, Boxes.Length);

                GameObject box = Instantiate(Boxes[rand_box]);
                box.transform.SetParent(Panel_Boxes);
                box.transform.position = new Vector3(6, 0, 0);

                createTime = 0;
            }

            text_score.text = score.ToString();
        }
    }

    public void Tap()
    {
        if (isStart == true)
        {
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.up * playerFlyForce;
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        Btn_GameStart.SetActive(false);

        for (int i = 0; i < Panel_Boxes.childCount; i++)
        {
            Destroy(Panel_Boxes.GetChild(i).gameObject);
        }

        createTime = 3;
        score = 0;

        Player.transform.position = new Vector3(0, -3, -1);
        Player.GetComponent<Rigidbody2D>().gravityScale = 3;


        isStart = true;
        
    }
}
