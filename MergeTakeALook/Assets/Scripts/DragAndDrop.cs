using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX, startPosY;
    private float initPosX, initPosY;
    private bool isLocked = false;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            Debug.Log(mousePos);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
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
            Debug.Log(mousePos);

            startPosX = this.transform.localPosition.x;
            startPosY = this.transform.localPosition.y;
            initPosX = mousePos.x - startPosX;
            initPosY = mousePos.y - startPosY;

            isLocked = true;
        }
    }

    private void OnMouseUp()
    {
        this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, this.gameObject.transform.localPosition.z);
        isLocked = false;
    }

}
