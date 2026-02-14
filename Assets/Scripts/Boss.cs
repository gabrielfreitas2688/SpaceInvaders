using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider hpBar;
    public Transform attackPoint;
    public GameObject boss;
    public GameObject prefabBulletSimple;
    public GameObject prefabBulletSpecial;
    Rigidbody2D rb;
    SpriteRenderer spriteBoss;
    bool isSpawnning = true;

    ////////////////////////////////////////////////
    public float hpMaxBoss = 100f;
    public float hpBoss;
    public float bossVelocity = 6f;
    int direcao = 1;
    float coolDown = 1.5f;


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
        if (isSpawnning)
        {
            BossMooveSpawn();
        }
        else
        {
            BoosMoove();
        }

        BossAttack();



    }

    void BossMooveSpawn()
    {
       transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 2.15f), bossVelocity * Time.deltaTime);
       if(transform.position.y == 2.15f)
        {
            isSpawnning = false;
        }        

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
        if (collision.gameObject.tag == "WallRight")
        {
            direcao = -1;
        }
        if (collision.gameObject.tag == "WallLeft")
        {
            direcao = 1;
        }

    }

    IEnumerator TomandoHit()
    {
        spriteBoss.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteBoss.color = Color.white;
    }

    void BoosMoove()
    {
        if(isSpawnning == false)
        {
            rb.linearVelocity = new Vector3(bossVelocity * direcao, 0, 0);
        }
       
    }

    void BossAttack()
    {

        if (coolDown >= 1.5f && isSpawnning == false)
        {
            int chooseAttack = Random.Range(0, 5);

            if(chooseAttack > 3)
            {
               Instantiate(prefabBulletSpecial, attackPoint.position, Quaternion.identity);
            }
            else { Instantiate(prefabBulletSimple, attackPoint.position, Quaternion.identity); }
            coolDown = 0;
        }
        else { coolDown += Time.deltaTime; }
    }
    
}
