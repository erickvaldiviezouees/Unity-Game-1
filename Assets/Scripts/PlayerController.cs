using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;
    public MyGameManager myGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        myGameManager = FindObjectOfType<MyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ItemGood")){
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }else if(collision.CompareTag("ItemBad")){
            Destroy(collision.gameObject);
            PlayerDeath();
        }else if(collision.CompareTag("DeathZone")){
            PlayerDeath();
        }
    }

    void PlayerDeath(){
        Debug.Log("Muerto");
        SceneManager.LoadScene("SampleScene");
    }

}