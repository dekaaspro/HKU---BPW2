using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShaderScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Material material;
    public GameObject hueShiftPoint;
    private GameObject player;

    
    void Start()
    {
        //material = GetComponent<SpriteRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");
        hueShiftPoint = GameObject.FindGameObjectWithTag("WorldCenter");
    }

    // Update is called once per frame
    void Update()
    {
        //material.SetFloat("_PlayerOffsetX",transform.position.x - player.transform.position.x);
        material.SetFloat("_PlayerOffsetX", hueShiftPoint.transform.position.x - player.transform.position.x);
    }
}
