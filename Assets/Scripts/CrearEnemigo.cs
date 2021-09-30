using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearEnemigo : MonoBehaviour
{
    public float genf = 45f;
    public GameObject  ZombiA;
    // Start is called before the first frame update
    void Start()
    {
        float PosXGenerador = Random.Range(-genf,genf);        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {      
            float PosXGenerador = Random.Range(-genf,genf); 
            var rotation = ZombiA.transform.rotation;
            Vector2 Aleatorio =  new Vector2(PosXGenerador,transform.position.y);
            Instantiate(ZombiA,Aleatorio,rotation);         
        } 
    }
}
