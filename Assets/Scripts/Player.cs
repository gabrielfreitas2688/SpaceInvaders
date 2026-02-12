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
}
