using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnController : MonoBehaviour
{
    public GameController Controller;
    public bool hasSpawned = false;
    // Start is called before the first frame update

    private void Awake()
    {
        Controller = FindObjectOfType<GameController>();
    }


    // Update is called once per frame
 

    private void OnMouseDown()
    {
        if (!hasSpawned)
        {
            Instantiate(Controller.Tower, gameObject.transform.position, gameObject.transform.rotation);
            hasSpawned = true;
            Debug.Log("shots");
        }
        else
        {
            Debug.Log("Already Spawned Tower");
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Whathappened");
    }
}
