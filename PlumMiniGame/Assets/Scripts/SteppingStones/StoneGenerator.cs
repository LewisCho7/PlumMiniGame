using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;


public struct CoolDown
{
    public float normal { get; set; }
    public float hard_brick { get; set; }
    public float hard_cloud { get; set; }
    public float hard_throne { get; set; }
}
public class StoneGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private GameObject throne_brick;
    [SerializeField]
    private GameObject spring;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject rescue;

    private List<GameObject> list = new List<GameObject>();
    private CoolDown cool_down = new CoolDown();

    // Start is called before the first frame update
    void Start()
    {
        cool_down.normal = 2.5f;
        cool_down.hard_brick = 3.5f;
        cool_down.hard_cloud = 2.5f;
        cool_down.hard_throne = 3;

        StartCoroutine(GenerateBrick());
        StartCoroutine(GenerateCloud());

        if(GameManager.hard_mode)
        {
            StartCoroutine(GenerateThroneBrick());
        }
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
            if (list[^1].transform.position.y - position.y <= 480)
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
            if(Random.Range(1, 101) <= 45)
            {
                GenerateBrickForSure();
                if (GameManager.hard_mode)
                {
                    yield return new WaitForSeconds(cool_down.hard_brick);
                }
                else
                {
                    yield return new WaitForSeconds(cool_down.normal);
                }
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

                if (GameManager.hard_mode)
                {
                    yield return new WaitForSeconds(cool_down.hard_cloud);
                }
                else
                {
                    yield return new WaitForSeconds(cool_down.normal);
                }
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

/*        if (Random.Range(1, 11) <= 1)
        {
            position.y += 50;
            GameObject new_spring = Instantiate(spring, position, Quaternion.identity);
            Destroy(new_spring, 10);
            position.y -= 50;
        }*/ //spring

        if (Random.Range(1, 11) <= 1)
        {
            position.y += 62;
            GameObject new_rescue = Instantiate(rescue, position, Quaternion.identity);
            Destroy(new_rescue, 10);
            position.y -= 62;
        } //character

        Destroy(new_brick, 15f);
    }

    IEnumerator GenerateThroneBrick()
    {
        while (GameManager.game_continue)
        {
            yield return null;
            if (Random.Range(1,101) <= 40)
            {
                var position 
                    = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
                var new_throne_brick = Instantiate(throne_brick, position, Quaternion.identity);
                list.Add(new_throne_brick);
                Destroy(new_throne_brick, 15f);
            }
            yield return new WaitForSeconds(cool_down.hard_throne);
        }
    }
}
