using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject m_camera;

    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    public GameObject p1_camera;
    public GameObject p2_camera;

    // Start is called before the first frame update
    void Start()
    {
        p1_camera = player1.transform.GetChild(0).gameObject;
        p2_camera = player2.transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        float dist = checkDistance();
        if (dist >= 12f)
        {
            disableMain();
        }
        else
        {
            disableSplit();
        }
    }

    public void disableMain()
    {
        p1_camera.SetActive(true);
        p2_camera.SetActive(true);
        m_camera.SetActive(false);
    }

    public void disableSplit()
    {
        m_camera.SetActive(true);
        p1_camera.SetActive(false);
        p2_camera.SetActive(false);
    }

    public float checkDistance()
    {
        Vector2 targ1 = player1.transform.position;
        Vector2 targ2 = player2.transform.position;
        return Vector2.Distance(targ1, targ2);
    }
}
