using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == points[current].position) 
        {
            IncreaseCurrent();

        }
        transform.position = Vector3.MoveTowards(transform.position, points[current].position, Speed * Time.deltaTime);
        
    }
    void IncreaseCurrent()
    {
        current++;
        if(current >= points.Length)
        {
            current = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CharacterController controller = collision.gameObject.GetComponent<CharacterController>();
            controller.enabled = false;
            controller.transform.position = new Vector3(4f, 6f, 8.64f);
            controller.enabled = true;
        }

    }
}
