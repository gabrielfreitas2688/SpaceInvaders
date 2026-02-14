using UnityEngine;

public class Defencer : MonoBehaviour
{
    EntityStates defencerEntity;
    public Sprite[] spriteDefencer;
    SpriteRenderer renderizador;
    int counter = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defencerEntity = gameObject.GetComponent<EntityStates>();
        renderizador = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            counter++;
            if (counter >= spriteDefencer.Length)
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                
            }
            else
            {
                renderizador.sprite = spriteDefencer[counter];
                Destroy(collision.gameObject);
            }
                
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }


    }

    
}
