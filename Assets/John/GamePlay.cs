using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject cat;
    public GameObject[] positions;
    public float time = 0f;
    public float maxLevel = 2f;
    public float gameMeters = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.mode == GameState.GameMode.playing)
        {
            if(GameState.gameScore > gameMeters+15)
            {
                if(GameState.level < 10)
                {
                    GameState.level++;
                }
                
                print("level: " + GameState.level);
                gameMeters = GameState.gameScore;
            }
           
            if (Time.time > time + maxLevel/GameState.level)
            {
                time = Time.time;
                var rand = Random.Range(0, positions.Length);
                var comp = Random.Range(0, positions.Length);
                if (Random.value > 0.5f)
                {
                    Instantiate(cat, positions[rand].transform.position, Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    if(comp == rand)
                    {
                        for (int i = 0; i < positions.Length; i++)
                        {
                            if (i != rand)
                            {
                                Instantiate(cat, positions[i].transform.position, Quaternion.Euler(0, 180, 0));
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < positions.Length; i++)
                        {
                            if (i != rand && i != comp)
                            {
                                Instantiate(cat, positions[i].transform.position, Quaternion.Euler(0, 180, 0));
                            }
                        }
                    }
                    
                }
                
            }
        }
        
    }
}
