using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularEditorScript : MonoBehaviour
{
    //Editable modular objects
    GameObject[] modularObjects;

    GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get up to date array of editable objects


        //If Mouse is clicked

        
    }

    void MouseClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;

            Debug.Log(mousePosition.x);
            Debug.Log(mousePosition.y);

            //If in selection Menu, pass to new shape selection 

            //Else if clicked button(s)

            //Else select an object or nothing
        }
    }

    int MouseClickRegion(Vector3 mousePosition, Vector2 regionSize)
    {
        //How wide is the screen?


        //Calculate for X


        //Calculate for Y


        return -1;//Failure
    }

    void NewShape(GameObject chosenShape)
    {
        //If no object is selected generate new Modular Shape object
        
        //Set selected object to generated 


    }

    void DeleteShape()
    {
        //Get parent 

        //Pass to parent
    }

    void SelectObject()
    {
        //Using Mouse position

        //Raycast to find what was clicked on

        
    }

    void SelectNewShape()
    {
        //Get region mouse clicked


        
        //Add shape to object

    }

    void ShapeOnCamera(GameObject prefab, Vector3 position)
    {
        //Create object

        //Parent to camera

        //Apply transform to object
    }

    void DisplayNewShapeGrid()
    {

        //For Y axis

        //For X axis

        //At edge of screen, exit x loop

        //

    }

    void CloseNewShapeGrid()
    {
        //For each shape in menu

        //destroy shape


    }

}
