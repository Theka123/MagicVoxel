using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    //복셀이 날아갈 속도 속성 
    public float speed = 5;

    public float destoryTime = 5.0f;

    float currentTime = 0; 
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = Random.insideUnitSphere; //크기가 1이고 방향만 존재함 

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > destoryTime)
        {
            Destroy(gameObject);
        }
    }
}
