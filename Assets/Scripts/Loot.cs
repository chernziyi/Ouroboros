using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private string lootType;
    [SerializeField] public GameObject player;

    public float scatterDistance;
    Vector3 offset;


    private void Start()
    {
        offset.x = Random.Range(scatterDistance * -1, scatterDistance);
        offset.y = Random.Range(scatterDistance * -1, scatterDistance);
        offset.z = 0;

        transform.position = transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LootGet()
    {
        if(lootType == "Soul")
        {
            player.GetComponent<PlayerLooter>().SoulGet(1);
            Debug.Log("Soul Reaped!");
        }
        else
        {

        }
        Destroy(gameObject);
        
    }
}
