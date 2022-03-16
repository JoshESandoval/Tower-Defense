using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float bulletSpeed,
                 lifeTime = 4f;
    Rigidbody2D bulletBody;

    public float damage;
    // Start is called before the first frame update

    private void Awake()
    {
       bulletBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
       
        bulletBody.AddForce(transform.up * bulletSpeed);
        Invoke("Disable", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            collision.GetComponent<EnemyControl>().TakeDamage(damage);
            Disable();
        }

    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
