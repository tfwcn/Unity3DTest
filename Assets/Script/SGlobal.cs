using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum State { Playing = 1, Play = 2, Stoping = 3, Stop = 4 }
public class SGlobal : MonoBehaviour
{
    public static State state = State.Stoping;
    public static List<GameObject> listCollisionObj1 = new List<GameObject>();
    public static int score = 0;
    public static int maxscore = 0;
    public static AndroidJavaClass jc;
    public static AndroidJavaObject jo;
    // original screen size
    public static float m_fScreenWidth = 800;
    public static float m_fScreenHeight = 480;

    public static Rect PositionLeft(ref Rect rect)
    {
        rect.x = 0;
        return rect;
    }
    public static Rect PositionRight(ref Rect rect)
    {
        rect.x = m_fScreenWidth - rect.width;
        return rect;
    }
    public static Rect PositionCenter(ref Rect rect)
    {
        rect.x = m_fScreenWidth / 2 - rect.width / 2;
        rect.y = m_fScreenHeight / 2 - rect.height / 2;
        return rect;
    }
    public static Rect PositionTop(ref Rect rect)
    {
        rect.y = 0;
        return rect;
    }
    public static Rect PositionBottom(ref Rect rect)
    {
        rect.y = m_fScreenHeight - rect.height;
        return rect;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
