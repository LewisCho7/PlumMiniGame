using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStones : MonoBehaviour
{
    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private GameObject spring;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject throne;
    [SerializeField]
    private GameObject rescue;

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
        var position 
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
        GameObject new_brick = Instantiate(brick, position, Quaternion.identity);

        if (Random.Range(1, 11) < 4)
        {
            position.y += 44;
            GameObject new_shield = Instantiate(shield, position, Quaternion.identity);
            Destroy(new_shield, 10);
        } //shield

        if (Random.Range(1, 11) < 4)
        {
            position.y += 71;
            GameObject new_spring = Instantiate(spring, position, Quaternion.identity);
            Destroy(new_spring, 10);
        } //spring

        if (Random.Range(1, 11) < 4)
        {
            position.y += 20;
            GameObject new_throne = Instantiate(throne, position, Quaternion.identity);
            Destroy(new_throne, 10);
        } //throne

        if (Random.Range(1, 11) < 4)
        {
            position.y += 70;
            GameObject new_rescue = Instantiate(rescue, position, Quaternion.identity);
            Destroy(new_rescue, 10);
        } //character
        step_is_generated = true;
        Destroy(new_brick, 10f);
    }
}
