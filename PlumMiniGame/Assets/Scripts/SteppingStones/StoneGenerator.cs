using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
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

    private List<GameObject> list = new List<GameObject>();

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
        var position = main_camera.transform.position;
        
        if(list.Count > 3)
        {
            list.RemoveAt(0);
        }

        if(list.Count > 0)
        {
            if (list[list.Count - 1].transform.position.y - position.y <= 480)
            {
                GenerateBrickForSure();
            }
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

                yield return new WaitForSeconds(2.5f - cool_down);
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
                list.Add(new_cloud);
                Destroy(new_cloud, 10f);

                yield return new WaitForSeconds(cool_down);
                yield return new WaitForSeconds(2.5f - cool_down);
            }
        }
    }

    void GenerateBrickForSure()
    {
        var position 
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
        GameObject new_brick = Instantiate(brick, position, Quaternion.identity);
        list.Add(new_brick);

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

        Destroy(new_brick, 15f);
    }
}
