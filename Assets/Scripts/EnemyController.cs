using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform shootPosition;
    public GameObject bulletEnemy;

    int intervaloTimer = 4;
    float cronometro = 0;

    void Start()
    {
       
    }

    void Update()
    {
        Cronometer();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletPlayer")
        {
            Destroy(this.gameObject);

            Destroy(collision.gameObject);

            GameManeger.Instance.AddPoints(10);
        }
    }

    void Cronometer()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= intervaloTimer)
        {
            cronometro = 0;
            int tryShoot = Random.Range(0, 11);
            if(tryShoot == 10)
            {
                Instantiate(bulletEnemy, shootPosition.position, Quaternion.identity);

;
            }
        }
        
    }

}
