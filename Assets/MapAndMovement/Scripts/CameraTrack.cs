using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField]
    private List<Transform> Players;
    [SerializeField]
    private Vector3 offset;
    private float speed = .5f;
    private Vector3 velo;

    private float minZoom = 60;
    private float maxZoom = 10;

    private Camera camera;

    void Start(){
        camera=GetComponent<Camera>();
    }
    void LateUpdate(){
        if(Players.Count==0){
            return;
        }
        move();
        zoom();
    }

    private void zoom(){
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getWidth()/10);
        camera.fieldOfView = newZoom;
    }
    private float getWidth(){
        var bounds = new Bounds(Players[0].position, Vector3.zero);
        bounds.Encapsulate(Players[1].position);
        return bounds.size.x;
    }
    private void move(){
        Vector3 center = getCenter();
        Vector3 newPos = center + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velo, speed);
    }
    private Vector3 getCenter(){
        if(Players.Count == 1){
            return Players[0].position;
        }
        else{
            var bounds = new Bounds(Players[0].position, Vector3.zero);
            bounds.Encapsulate(Players[1].position);
            return bounds.center;
        }
    }

}
