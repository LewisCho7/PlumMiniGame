using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStones : MonoBehaviour
{

    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private GameObject spring;
    [SerializeField]
    private GameObject shield;

    private bool step_is_generated;
    private bool cloud_is_generated;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateBrick());
        StartCoroutine(GenerateCloud());
    }

    // Update is called once per frame
    void Update()
    {
        if(!step_is_generated)
        {
            StartCoroutine(CheckStepIsGenerated());
        }
        if (!GameManager.game_continue)
            StopAllCoroutines();
    }

    IEnumerator GenerateBrick()
    {
        var cool_down = new WaitForSeconds(1.2f);
        while (true)
        {
            yield return null;
            int chance = Random.Range(1, 11);
            if(chance < 7)
            {
                GenerateBrickForSure();
            }
            else
            {
                step_is_generated = false;
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
                GameObject new_cloud = Instantiate(cloud);
                cloud_is_generated = true;
                Destroy(new_cloud, 10f);
            }
            else
            {
                cloud_is_generated = false;
            }
            yield return cool_down;
        }
    }

    IEnumerator CheckStepIsGenerated()
    {
        yield return new WaitForSeconds(2);
        if (!cloud_is_generated && !step_is_generated)
        {
            GenerateBrickForSure();
        }
    }

    void GenerateBrickForSure()
    {
        GameObject new_brick = Instantiate(brick);
        /*        if (Random.Range(1, 11) < 4)
                {
                    GameObject new_spring = Instantiate(spring);
                    new_spring.transform.position
                        = new Vector3(new_brick.transform.position.x, new_brick.transform.position.y + 10, 0);

                }*/
        GameObject new_spring = Instantiate(spring);
        new_spring.transform.position
            = new Vector3(new_brick.transform.position.x, new_brick.transform.position.y + 10, 0);

/*        if (Random.Range(1, 11) < 4)
        {
            GameObject new_spring = Instantiate(spring);
            new_spring.transform.position
                = new Vector3(new_brick.GetComponent<Brick>().x, new_brick.GetComponent<Brick>().y + 10, 0);

        }*/
        step_is_generated = true;
        Destroy(new_brick, 10f);
    }
}
