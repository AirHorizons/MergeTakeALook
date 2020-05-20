using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX, startPosY;
    private float initPosX, initPosY;
    private bool isLocked = false;

    public Sprite normalCat;
    public Sprite holdCat;

    public GameObject CatSlots;

    private List<GameObject> collided;

    void Start()
    {
        collided = new List<GameObject>();
        CatSlots = GameObject.Find("CatSlots");

        if (CatSlots == null)
            Debug.Log("Warning: Cannot find CatSlots!");
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

            Debug.Log(startPosX + " " + startPosY  + " " + initPosX + " " + initPosY);

            // change sprite
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = holdCat;

            // turn Rigidbody2d  of other cats off
            foreach (Transform catslot in CatSlots.transform)
            {
                // catslot has a cat
                if (catslot.childCount > 0 && catslot.GetChild(0) != gameObject.transform)
                {
                    catslot.GetChild(0).gameObject.GetComponent<Rigidbody2D>().simulated = false;
                }
            }

            isLocked = true;
        }
    }

    private void OnMouseUp()
    {
        GameObject nearestSlot = null;
        Transform swapCat = null;
        float swapCatPosX, swapCatPosY;

        float mindistance = 99999f;

        if (collided.Count > 0)
        {
            // find nearest cat slot
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
                // change slots or merge cat
                if (nearestSlot.transform != transform.parent && nearestSlot.GetComponent<CatSlot>().isCatMounted)
                {
                    // merge cat
                    if (this.GetComponent<NormalTakeALook>().catLevel == nearestSlot.transform.GetChild(0).GetComponent<NormalTakeALook>().catLevel)
                    {
                        // TODO: Merge cat into other slot
                        Debug.Log("MergeCat");
                    }

                    // swap cat
                    else
                    {
                        swapCat = nearestSlot.transform.GetChild(0);
                        swapCat.parent = transform.parent;
                        transform.parent = nearestSlot.transform;
                        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = normalCat;
                    }
                }
                // move cat
                else
                {
                    transform.parent = nearestSlot.transform;
                    transform.localPosition = new Vector3(startPosX, startPosY, 0);
                    gameObject.GetComponentInChildren<SpriteRenderer>().sprite = normalCat;
                }
            }

            foreach (Transform catslot in CatSlots.transform)
            {
                // catslot has a cat
                if (catslot.childCount > 0 && catslot.GetChild(0) != gameObject.transform)
                {
                    catslot.GetChild(0).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }


        transform.localPosition = new Vector3(startPosX, startPosY, 0);
        if (swapCat != null) swapCat.localPosition = new Vector3(0, 0, 0);
        isLocked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided.Remove(collision.gameObject);
    }
}
