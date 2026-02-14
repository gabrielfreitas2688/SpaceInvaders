using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EntityStates enemyEntity;
    public GameObject enemy;
    Rigidbody2D rb;
    int direcao = 1; 

    
    void Start()
    {
        enemyEntity = gameObject.GetComponent<EntityStates>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        SpawnEnemy();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoove();
    }

    void SpawnEnemy()
    {

        int colunas = 10;
        int linhas = 3;

        for (int l = 0; l < linhas; l++)
        {
            for(int c = -10; c < colunas; c+=2)
            {
                Instantiate(enemy, transform.position + new Vector3((c / 1.5f), -l, 0), Quaternion.identity, transform);
            }
        }
        
    }

    void EnemyMoove()
    {
        rb.linearVelocity = new Vector2(enemyEntity.mooveSpeed * direcao, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WallRight" && direcao > 0)
        {
            direcao *= -1;
            transform.position += new Vector3(0, -0.05f, 0);
            enemyEntity.mooveSpeed += 0.02f;
        }
        else if(collision.gameObject.tag == "WallLeft" && direcao < 0)
        {
            direcao *= -1;
            transform.position += new Vector3(0, -0.05f, 0);
            enemyEntity.mooveSpeed += 0.02f;
        }
    }
}
