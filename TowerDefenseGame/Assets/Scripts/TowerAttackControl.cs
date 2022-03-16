using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackControl : MonoBehaviour
{
    public float attackSpeed,
                 roatationSpeed,
                 attackRange;
    public Transform target,
                    child;
    float cools;
    public GameObject bullet;
   
    private void Awake()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
        cools = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 direction = target.transform.position - child.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            child.rotation = Quaternion.Lerp(child.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * roatationSpeed);

            if(cools > 0)
            {
                cools -= Time.deltaTime;
            }
            else
            {
                ShootBullet();
            }
        }
    }

    void ShootBullet()
    {
        Instantiate(bullet, child.position, child.rotation);
        cools = attackSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && target == null)
        {
            target = collision.gameObject.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && target == null) {
            target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && target == collision.transform)
        {
            target = null;
        }
    }
}
