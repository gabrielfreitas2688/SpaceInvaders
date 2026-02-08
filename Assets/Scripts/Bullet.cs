using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    EntityStates bulletEntity;
    
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

    void BulletShoot()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bulletEntity.bulletSpeed);
    }


}
