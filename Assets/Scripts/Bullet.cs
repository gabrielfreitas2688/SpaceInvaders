using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    EntityStates bulletEntity;
    public bool isEnemyBullet;
    
    void Start()
    {
        Destroy(this.gameObject, 1.2f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletEntity = gameObject.GetComponent<EntityStates>();
        BulletShoot();
    }

    void Update()
    {
        
    }

    public void BulletShoot()
    {
        if (isEnemyBullet)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bulletEntity.bulletSpeed * -1);
        }
        else { rb.linearVelocity = new Vector2(rb.linearVelocity.x, bulletEntity.bulletSpeed); }
           
    }


}
