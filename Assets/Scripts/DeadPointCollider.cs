using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPointCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCome = false;
    public GameObject monster;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")     //player has collided with trigger
        {
            if (gameManager.GetComponent<GameManager>().clearCount < 1)
            {
                if (!isCome)
                {
                    Instantiate(monster);
                    isCome = true;
                }
            }
            else
            {
                SceneManager.LoadScene("GameClearScene");
            }
        }
    }
}
