using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnifeController : MonoBehaviour
{
    public float hitSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            enemy.AddForce(this.transform.forward * hitSpeed, ForceMode.Impulse);
        }
    }

}
