using UnityEngine;
using System.Collections;

public class SBollAI : MonoBehaviour
{
    public float steep = 0.1f;
    public Material MBoll1;
    public Material MBoll2;
    public Texture btnLeft;
    public Texture btnRight;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(Vector3.up * 2 * Time.deltaTime * 60);
        if (SGlobal.state == State.Play)
        {
            float inputX = Input.GetAxis("Horizontal");
            if (inputX < 0)
            {
                rigidbody.AddForce(Vector3.left * steep * Time.deltaTime * 60);
            }
            else if (inputX > 0)
            {
                rigidbody.AddForce(Vector3.left * -steep * Time.deltaTime * 60);
            }
        }
    }
    void OnGUI()
    {
        using (HGUISizeLocker guiLock = new HGUISizeLocker())
        {
            if (SGlobal.state == State.Play)
            {
                Rect rect = new Rect(0, 0, 80, 40);
                SGlobal.PositionBottom(ref rect);
                if (GUI.RepeatButton(rect, btnLeft))
                {
                    rigidbody.AddForce(Vector3.left * steep * Time.deltaTime * 60);
                }
                Rect rect2 = new Rect(0, 0, 80, 40);
                SGlobal.PositionRight(ref rect2);
                SGlobal.PositionBottom(ref rect2);
                if (GUI.RepeatButton(rect2, btnRight))
                {
                    rigidbody.AddForce(Vector3.left * -steep * Time.deltaTime * 60);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (SGlobal.state == State.Play && collision.gameObject.name == "CollisionObj")
        {
            //Debug.Log(collision.gameObject.name);
            SGlobal.state = State.Stoping;
            GameObject obj = GameObject.Find("Particle System");
            obj.particleSystem.Stop();
            GameObject EndHide = GameObject.Find("EndHide");
            EndHide.collider.enabled = false;
            if (SGlobal.maxscore < SGlobal.score)
            {
                SGlobal.maxscore = SGlobal.score;
                PlayerPrefs.SetInt("Score", SGlobal.maxscore);
                PlayerPrefs.Save();
            }
            //SMain.ShowAD2();
            //light.enabled = false;
            //renderer.material = MBoll2;
        }
    }
}
