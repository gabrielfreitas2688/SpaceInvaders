using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider hpBar;
    public GameObject boss;
    Rigidbody2D rb;
    SpriteRenderer spriteBoss;

    ////////////////////////////////////////////////
    public float hpMaxBoss = 100f;
    public float hpBoss;
    public float bossVelocity = 5f;


    void Start()
    {
        spriteBoss = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        hpBoss = hpMaxBoss;
        hpBar.maxValue = hpMaxBoss;
        hpBar.value = hpBoss;


        hpBar.gameObject.SetActive(true);
    }


    void Update()
    {
        BossMooveSpawn();
    }

    void BossMooveSpawn()
    {
       transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 2.65f), bossVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletPlayer")
        {
            hpBoss -= 5;
            hpBar.value = hpBoss;
            Destroy(collision.gameObject);
            StartCoroutine(TomandoHit());

            if (hpBoss <= 0)
            {
                GameManeger.Instance.Win();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator TomandoHit()
    {
        spriteBoss.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteBoss.color = Color.white;
    }
}
