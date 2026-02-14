using UnityEngine;

public class BulletBoss : MonoBehaviour
{

    private Rigidbody2D rb;
    public int bulletSpeed = 15;

    void Start()
    {
        Destroy(this.gameObject, 1.2f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        BulletShoot();
    }

    void Update()
    {

    }

    public void BulletShoot()
    {

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bulletSpeed * -1);


    }
}
