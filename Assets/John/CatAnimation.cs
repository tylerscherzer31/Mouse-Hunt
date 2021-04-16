using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    private Animator animator;
    private float speed = 10;
    private GameObject mouse;
    private Vector3[] offsets = {Vector3.right, Vector3.left, Vector3.forward };
    private Color[] colors = { Color.black, Color.white, Color.gray, Color.yellow};
    private Vector3 setOffset;
    public bool eating = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
        animator.Play("Walk");
        mouse = GameObject.FindGameObjectWithTag("Player");
        setOffset = offsets[Random.Range(0,offsets.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.mode == GameState.GameMode.playing)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z < -10.54)
            {
                Destroy(this.gameObject);
            }
        }else if(GameState.mode == GameState.GameMode.dead)
        {
            if (eating)
            {
                Vector3 newPos = mouse.transform.position + Vector3.forward;
                transform.position = newPos;
                animator.Play("Eat");
            }
            else
            {
                animator.Play("Jump");
            }
            //Vector3 pos = mouse.transform.position;
            //pos = pos + setOffset/2;
            //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
            //transform.LookAt(mouse.transform);
            //if(transform.position.x == pos.x && transform.position.z == pos.z)
            //{
                
            //        animator.Play("Eat");
                

            //}
        }
        
    }
}
