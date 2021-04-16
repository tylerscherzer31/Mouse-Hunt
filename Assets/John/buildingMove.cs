using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingMove : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.mode == GameState.GameMode.playing)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (transform.position.z < -11f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 15.12f);
            }
        }

    }
}
