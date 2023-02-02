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
    private GameObject rescue;

    private bool step_is_generated;
    private bool cloud_is_generated;

    [SerializeField]
    private float cool_down;
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
        while (true)
        {
            yield return null;
            if(Random.Range(1, 101) <= 60)
            {
                GenerateBrickForSure();
                yield return new WaitForSeconds(cool_down);
                step_is_generated = false;
                yield return new WaitForSeconds(2.5f - cool_down);
            }
            else
            {
                step_is_generated = false;
                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    IEnumerator GenerateCloud()
    {
        while (true)
        {
            yield return null;
            var position
                = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
            if (Random.Range(1, 101) <= 40)
            {
                GameObject new_cloud = Instantiate(cloud, position, Quaternion.identity);
                cloud_is_generated = true;
                Destroy(new_cloud, 10f);

                yield return new WaitForSeconds(cool_down);
                cloud_is_generated = false;
                yield return new WaitForSeconds(2.5f - cool_down);
            }
            else
            {
                cloud_is_generated = false;
                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    IEnumerator CheckStepIsGenerated()
    {
        yield return new WaitForSeconds(cool_down);
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

        if (Random.Range(1, 11) <= 1)
        {
            position.y += 60;
            GameObject new_shield = Instantiate(shield, position, Quaternion.identity);
            Destroy(new_shield, 10);
            position.y -= 60;
        } //shield

        if (Random.Range(1, 11) <= 1)
        {
            position.y += 50;
            GameObject new_spring = Instantiate(spring, position, Quaternion.identity);
            Destroy(new_spring, 10);
            position.y -= 50;
        } //spring

        if (Random.Range(1, 11) <= 1)
        {
            position.y += 62;
            GameObject new_rescue = Instantiate(rescue, position, Quaternion.identity);
            Destroy(new_rescue, 10);
            position.y -= 62;
        } //character

        step_is_generated = true;
        Destroy(new_brick, 10f);
    }
}
