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

    public static CoolDown instance;
}
public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject[] brick;
    [SerializeField]
    private GameObject[] cloud;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject rescue;

    private GameObject last_platform;

    // Start is called before the first frame update
    void Start()
    {
        CoolDown.instance.normal = 2.5f;
        CoolDown.instance.hard_brick = 3.5f;
        CoolDown.instance.hard_cloud = 2.5f;
        CoolDown.instance.hard_throne = 3;

        StartCoroutine(GenerateBrick());
        StartCoroutine(GenerateCloud());

        if (JumpGameManager.hard_mode)
        {
            StartCoroutine(GenerateThroneBrick());
        }

        last_platform = GameObject.Find("brick_1 (5)");
    }

    // Update is called once per frame
    void Update()
    {
        var position = main_camera.transform.position;
        if (last_platform.transform.position.y - position.y <= 480 && JumpGameManager.on_going)
        {
            GenerateBrickForSure();
        }
    }

    IEnumerator GenerateBrick()
    {
        while (true)
        {
            yield return null;
            if (Random.Range(1, 101) <= 45)
            {
                GenerateBrickForSure();
                if (JumpGameManager.hard_mode)
                {
                    yield return new WaitForSeconds(CoolDown.instance.hard_brick);
                }
                else
                {
                    yield return new WaitForSeconds(CoolDown.instance.normal);
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
                GameObject new_cloud = Instantiate(cloud[0], position, Quaternion.identity);
                if (JumpGameManager.hard_mode)
                {
                    yield return new WaitForSeconds(CoolDown.instance.hard_cloud);
                }
                else
                {
                    yield return new WaitForSeconds(CoolDown.instance.normal);
                }
            }
        }
    }

    void GenerateBrickForSure()
    {
        var position
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
        GameObject new_brick = Instantiate(brick[0], position, Quaternion.identity);
        last_platform = new_brick;

        //shield
        if (Random.Range(1, 11) <= 1)
        {
            position.y += 60;
            GameObject new_shield = Instantiate(shield, position, Quaternion.identity);
            position.y -= 60;
        }

        //spring
        /*if (Random.Range(1, 11) <= 1)
                {
                    position.y += 50;
                    GameObject new_spring = Instantiate(spring, position, Quaternion.identity);
                    Destroy(new_spring, 10);
                    position.y -= 50;
                }*/ 

        //character
        if (Random.Range(1, 11) <= 1)
        {
            position.y += 62;
            GameObject new_rescue = Instantiate(rescue, position, Quaternion.identity);
            position.y -= 62;
        }
    }

    IEnumerator GenerateThroneBrick()
    {
        while (JumpGameManager.on_going)
        {
            yield return null;
            if (Random.Range(1, 101) <= 40)
            {
                var position
                    = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
                var new_throne_brick = Instantiate(brick[2], position, Quaternion.identity);
                last_platform = new_throne_brick;
            }
            yield return new WaitForSeconds(CoolDown.instance.hard_throne);
        }
        
    }
}