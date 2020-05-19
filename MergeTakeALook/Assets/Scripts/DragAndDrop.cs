using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX, startPosY;
    private float initPosX, initPosY;
    private bool isLocked = false;

    private List<GameObject> collided;

    void Start()
    {
        collided = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - initPosX, mousePos.y  - initPosY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = this.transform.localPosition.x;
            startPosY = this.transform.localPosition.y;
            initPosX = mousePos.x - startPosX;
            initPosY = mousePos.y - startPosY;

            isLocked = true;
        }
    }

    private void OnMouseUp()
    {
        GameObject nearestSlot = null;

        float mindistance = 99999f;
        Debug.Log(collided.Count);
        if (collided.Count > 0)
        {
            foreach (GameObject collidedObject in collided)
            {
                if (collidedObject.GetComponent<CatSlot>() != null && (Vector3.Distance(this.transform.position, collidedObject.transform.position)) < mindistance)
                {
                    mindistance = Vector3.Distance(this.transform.position, collidedObject.transform.position);
                    nearestSlot = collidedObject;
                }
            }

            if (nearestSlot != null)
            {
                if (nearestSlot.GetComponent<CatSlot>().isCatMounted)
                {

                }
                else
                {
                    this.transform.parent = nearestSlot.transform;
                }
            }
        }

        this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, this.gameObject.transform.localPosition.z);
        isLocked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        collided.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided.Remove(collision.gameObject);
    }
}
