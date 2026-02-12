using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    int intervaloTimer = 4;
    float cronometro = 0;

    void Start()
    {
        
    }

    void Update()
    {
        EnemyShoot();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);

            Destroy(collision.gameObject);
        }
    }

    void EnemyShoot()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= intervaloTimer)
        {
            cronometro = 0;
            int tryShoot = Random.Range(0, 30);
            if(tryShoot == 10)
            {
                Debug.Log("Tiro!");
;
            }
        }
        
    }
}
