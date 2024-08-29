using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Managing Player Movement here

    public static PlayerManager instance;

    [SerializeField]
    private float yOffset = 0f;
    [SerializeField]
    private float Offset = 0.02f;
    [SerializeField]
    private float speed = 1f;

    private Animation anim;

    public bool movePlayer = false;
    private Vector3 finalPos;

    public void Start()
    {
        anim = transform.GetComponentInChildren<Animation>();

        if(instance == null)
        {
            instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:

                    Vector3 touchPos = touch.position;
                    finalPos = GetWorldPosition(touchPos);

                    // Make player look at touch position
                    transform.LookAt(finalPos);
                    movePlayer = true;
          
                    anim.Play();
                    break;
            }

        }

        // Making Player Move
        MovePlayer();
    }

    void MovePlayer()
    {
        if(movePlayer)
        {
            Vector3 dir = (finalPos - transform.position);
            float distance = dir.magnitude;

            if (distance > Offset)
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            else
            {
                movePlayer = false;
                anim.Stop();
            }
        }
    }


    Vector3 GetWorldPosition(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit hit;
        Vector3 ret = new Vector3();

        if (Physics.Raycast(ray, out hit))
        {
            ret = hit.point;
        }

        return new Vector3(ret.x, yOffset, ret.z);
    }
}
