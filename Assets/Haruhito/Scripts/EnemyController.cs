using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject enemy;
    Vector2 pos = new Vector2(0.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += 0.01f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x += -0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y += -0.01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 0.01f;
        }

        this.enemy.transform.position = pos;
    }
}
