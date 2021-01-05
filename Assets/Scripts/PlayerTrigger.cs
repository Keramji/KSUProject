using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Score")
        {
            GM.score += 1;
        }
    }
}
