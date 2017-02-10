using UnityEngine;
using System.Collections;

public class SQMove : MonoBehaviour
{
    public float steep = 0.1f;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(Random.value * 8 - 4, 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (SGlobal.state == State.Play)
        {
            //Debug.Log(Time.deltaTime + "," + (Time.deltaTime * 60));
            transform.Translate(Vector3.back * steep * Time.deltaTime * 60);
            if (transform.position.z < -5)
            {
                Destroy(gameObject);
                SGlobal.listCollisionObj1.Remove(gameObject);
                SGlobal.score++;
            }
        }
    }
}
