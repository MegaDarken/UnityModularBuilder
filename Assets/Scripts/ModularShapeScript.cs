using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularShapeScript : MonoBehaviour
{
    //Vector of last mouse position
    private Vector3 previousPosition;
    private Vector3 previousMousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Select on Click
    private void OnMouseDown()
    {
        //set previous position
        previousPosition = gameObject.transform.position;
        previousMousePosition = MouseVector();

        //Select object
        SelectShape();
    }

    private void OnMouseDrag()
    {
        //find distance from previous position
        //Move selected object
        gameObject.transform.position = previousPosition + (MouseVector() - previousMousePosition);

    }

    private Vector3 MouseVector()
    {
        //Get dimention position
        Vector3 mousePosition = Input.mousePosition;

        //set Z to Clip Plane
        mousePosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    
    void SelectShape()
    {
        //Pass reference for this object into ModularEditorScript

    }

    void NewShape()
    {
        //Create shape


        //Set parent to root as this object


    }

    void DeleteShape()
    {
        //Delete object


    }

}
