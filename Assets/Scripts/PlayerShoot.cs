using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    EntityStates playerShootStates;
    public Transform pontoSaidaBullet;
    public GameObject bullet;
    bool canShoot = true;
    float coolDown;
    void Start()
    {
        playerShootStates = gameObject.GetComponent<EntityStates>();
        coolDown = playerShootStates.attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
        CoolDown();    
    }

    void Shooting()
    {
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            Instantiate(bullet, pontoSaidaBullet.transform.position , Quaternion.identity);
            canShoot = false;
            coolDown = 0;
        }
    }

    void CoolDown()
    {
        if(coolDown >= playerShootStates.attackSpeed && canShoot == false)
        {
            canShoot = true;    
        }
        else
        {
            coolDown += Time.deltaTime;
        }
    }



}


