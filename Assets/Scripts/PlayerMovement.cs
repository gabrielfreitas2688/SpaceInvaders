using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    EntityStates playerEntity;
    Rigidbody2D rb;

    void Start()
    {
        playerEntity = gameObject.GetComponent<EntityStates>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoove();
    }

    void PlayerMoove()
    {
        float direcao = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(playerEntity.mooveSpeed * direcao, rb.linearVelocity.y);


    }
}
