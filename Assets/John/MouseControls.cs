using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControls : MonoBehaviour
{
    public GameObject[] positions;
    public bool reset = true;
    public int positionIndex = 1;
    public bool gameStart = false;
    public AudioClip mouseSqueak;
    public AudioClip catSkreach;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.mode == GameState.GameMode.playing && !gameStart)
        {
            transform.position = positions[positionIndex].transform.position;
            gameStart = true;
        }
        else if(GameState.mode == GameState.GameMode.playing)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (positionIndex - 1 > -1)
                {
                    positionIndex -= 1;
                    transform.position = positions[positionIndex].transform.position;
                    audioSource.PlayOneShot(mouseSqueak);
                    reset = false;

                }




            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (positionIndex + 1 < positions.Length)
                {
                    positionIndex += 1;
                    transform.position = positions[positionIndex].transform.position;
                    audioSource.PlayOneShot(mouseSqueak);
                    reset = false;

                }




            }
            else
            {
                reset = true;
            }
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "cat")
        {
            other.gameObject.GetComponent<CatAnimation>().eating = true;
            GameState.mode = GameState.GameMode.dead;
            audioSource.PlayOneShot(catSkreach);
            StartCoroutine(EndTheGame());
        }
    }
    IEnumerator EndTheGame()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(2);
    }
}
