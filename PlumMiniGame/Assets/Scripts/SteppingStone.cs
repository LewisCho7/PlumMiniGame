using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStone : MonoBehaviour
{
    public bool step_is_generated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateBrick()
    {
        var cool_down = new WaitForSeconds(1);
        while (true)
        {
            yield return null;
            int chance = Random.Range(1, 11);
            if(chance < 7)
            {
                //寒积己
            }
            yield return cool_down;
        }
    }
    IEnumerator GenerateCloud()
    {
        var cool_down = new WaitForSeconds(5);
        while (true)
        {
            yield return null;
            int chance = Random.Range(1, 11);
            if (chance < 5)
            {
                //寒积己
            }
            yield return cool_down;
        }
    }
}
