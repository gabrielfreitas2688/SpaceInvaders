using System.Collections;
using UnityEngine;

public class BuleltBossSplit : MonoBehaviour
{
    [Header("Configurações")]
    public float explosionTimer = 1.5f; 
    public int bulletSpeed = 5;
    public GameObject specialBullet;
    public int tiros = 8;

    private bool exploded = false;
    private bool chegouNoPonto = false;
    private Vector2 destinoLinhaReta;

    void Start()
    {
        destinoLinhaReta = new Vector2(transform.position.x, 0.39f);

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        
        if (!chegouNoPonto)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinoLinhaReta, bulletSpeed * Time.deltaTime);

            // 2. Verifica se chegou
            if (Vector2.Distance(transform.position, destinoLinhaReta) < 0.1f)
            {
                chegouNoPonto = true;
                StartCoroutine(TimerExplosion());
            }
        }
    }

    IEnumerator TimerExplosion()
    {

        yield return new WaitForSeconds(explosionTimer);

        if (!exploded)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        exploded = true;

        for (int i = 0; i < tiros; i++)
        {
            float angulo = i * (360f / tiros);
            float dirX = Mathf.Cos(angulo * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angulo * Mathf.Deg2Rad);

            Vector2 direcaoDoTiro = new Vector2(dirX, dirY);


            GameObject miniTiro = Instantiate(specialBullet, transform.position, Quaternion.identity);

            
            Destroy(miniTiro, 3f);

            Rigidbody2D rbMini = miniTiro.GetComponent<Rigidbody2D>();
            if (rbMini != null)
            {
                rbMini.linearVelocity = direcaoDoTiro * bulletSpeed * 1.5f;
            }
        }

      
        Destroy(gameObject);
    }
}