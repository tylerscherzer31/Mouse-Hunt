using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRun : MonoBehaviour
{
    public GameObject bloodAndChuncks;
    private Animator m_animator;
    private bool gameStart = false;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.mode == GameState.GameMode.playing && !gameStart)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            m_animator.SetInteger("AnimIndex", 1);
            m_animator.SetTrigger("Next");
            gameStart = true;
        }else if(GameState.mode == GameState.GameMode.dead)
        {
            m_animator.SetTrigger("dead");
            rigidbody.isKinematic = true;
            transform.rotation = Quaternion.Euler(new Vector3(-90, 180, 0));
            bloodAndChuncks.SetActive(true);
        }
    }
}
