using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    EntityStates playerEntity;
    public Slider hpBar;
    
    void Start()
    {
        playerEntity = gameObject.GetComponent<EntityStates>();

        playerEntity.hp = playerEntity.maxHp;
        

    }


    void Update()
    {
        PlayerHP();
    }

    void PlayerHP()
    {
        hpBar.maxValue = playerEntity.maxHp;
        hpBar.value = playerEntity.hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletEnemy")
        {
            TomarDano(playerEntity.damageEnemy);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            GameManeger.Instance.GameOver();
        }
    }

    void TomarDano(float dano)
    {
        playerEntity.hp -= dano;

        if (playerEntity.hp <= 0)
        {
            playerEntity.hp = 0;
            GameManeger.Instance.GameOver();
        }
    }
}
