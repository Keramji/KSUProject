using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boxes")
        {
            Time.timeScale = 0;
            GM.Btn_GameStart.SetActive(true);
            Debug.Log("Hit the Box!");
        }
    }
}
