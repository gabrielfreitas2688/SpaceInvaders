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
        Instantiate(enemy, transform.position, Quaternion.identity, transform);
    }

    void EnemyMoove()
    {
        rb.linearVelocity = new Vector2(enemyEntity.mooveSpeed * direcao, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            direcao *= -1;
        }
    }
}
