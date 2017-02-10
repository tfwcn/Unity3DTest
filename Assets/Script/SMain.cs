using UnityEngine;
using System.Collections;

public class SMain : MonoBehaviour
{
    public float time1 = 0f;
    public float time2 = 3f;
    public GameObject CollisionObj1;
    public GameObject CollisionObj2;
    public GameObject CollisionObj3;
    public Texture btnPlay;
    // Use this for initialization  

    public static void ShowAD()
    {
        if (Application.platform == RuntimePlatform.Android)
            SGlobal.jo.Call("ShowAD");
    }

    public static void ShowAD2()
    {
        if (Application.platform == RuntimePlatform.Android)
            SGlobal.jo.Call("ShowAD2");
    }

    public static void CloseAD2()
    {
        if (Application.platform == RuntimePlatform.Android)
            SGlobal.jo.Call("CloseAD2");
    }

    void Start()
    {
        SGlobal.maxscore = PlayerPrefs.GetInt("Score", 0);
        InvokeRepeating("CreateObj", time1, time2);
        if (Application.platform == RuntimePlatform.Android)
        {
            SGlobal.jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            SGlobal.jo = SGlobal.jc.GetStatic<AndroidJavaObject>("currentActivity");
        }
        ShowAD();
        ShowAD2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
        {
            Application.Quit();
        }
        if (SGlobal.state == State.Playing)
        {
            CloseAD2();
            SGlobal.state = State.Play;
        }
        if (SGlobal.state == State.Stoping)
        {
            ShowAD2();
            SGlobal.state = State.Stop;
        }
    }
    void CreateObj()
    {
        if (SGlobal.state == State.Play)
        {
            Debug.Log("CreateObj");
            float ran = Random.value*15;
            if (ran < 5)
            {
                SGlobal.listCollisionObj1.Add(Instantiate(CollisionObj1) as GameObject);
            }
            else if (ran < 10)
            {
                SGlobal.listCollisionObj1.Add(Instantiate(CollisionObj2) as GameObject);
            }
            else
            {
                SGlobal.listCollisionObj1.Add(Instantiate(CollisionObj3) as GameObject);
            }
        }
    }
    void OnGUI()
    {
        using (HGUISizeLocker guiLock = new HGUISizeLocker())
        {
            if (SGlobal.state == State.Stop)
            {
                Rect rect = new Rect(0, 0, 80, 40);
                SGlobal.PositionCenter(ref rect);
                if (GUI.Button(rect, btnPlay))
                {
                    Reset();
                    SGlobal.state = State.Playing;
                }
            }
            //else if (SGlobal.state == State.Play)
            {
                GUIStyle style = new GUIStyle();
                style.fontSize = 30;
                style.normal.textColor = Color.green;
                Rect rect = new Rect(0, 0, 160, 30);
                SGlobal.PositionRight(ref rect);
                GUI.Label(rect, "Score:" + SGlobal.score.ToString(), style);
                Rect rect2 = new Rect(0, 0, 200, 30);
                GUI.Label(rect2, "MaxScore:" + SGlobal.maxscore.ToString(), style);
            }
        }
    }
    void Reset()
    {
        GameObject Sphere = GameObject.Find("Sphere");
        Sphere.transform.position = new Vector3(0, 1.5f, 0);
        foreach (var gameobj in SGlobal.listCollisionObj1)
        {
            Destroy(gameobj);
        }
        SGlobal.listCollisionObj1.Clear();
        GameObject obj = GameObject.Find("Particle System");
        obj.particleSystem.Play();
        SGlobal.score = 0;
        GameObject EndHide = GameObject.Find("EndHide");
        EndHide.collider.enabled = true;
    }
}
