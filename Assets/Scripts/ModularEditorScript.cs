using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularEditorScript : MonoBehaviour
{
    //Editable modular objects
    GameObject[] modularObjects;
    List<GameObject> menuShapes;

    GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get up to date array of editable objects
        modularObjects = GameObject.FindGameObjectsWithTag("ModularShape")

        //If Mouse is clicked
        MouseClick();

    }

    void MouseClick()
    {
        //Left Mouse Button
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;

            Debug.Log(mousePosition.x);
            Debug.Log(mousePosition.y);

            //If in selection Menu, pass to new shape selection 

            //Else if clicked button(s)

            //Else select an object or nothing
        }

        //Right Mouse Button

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


        //Close Menu
        CloseNewShapeGrid();
        
        //Add shape to object

    }

    void ShapeOnCamera(GameObject prefab, Vector3 position)
    {
        //Create object
        GameObject cameraShape = Instantiate(prefab);

        //Parent to camera
        cameraShape.transform.SetParent(Camera.main.transform, false);

        //Apply transform to object
        cameraShape.transform.localPosition = position;

        //Add to list
        menuShapes.Add(cameraShape);
    }

    void DisplayNewShapeGrid()
    {


        Vector3 position = Vector3.forward;

        int xIndex, yIndex;
        xIndex = yIndex = 0;

        foreach(GameObject shape in modularObjects)
        {
            //for next shape

            //Attach to camera
            ShapeOnCamera(shape, position);
        
            xIndex++;//Increment X position
        }

        //

    }

    void CloseNewShapeGrid()
    {
        //For each shape in menu
        foreach (GameObject shape in menuShapes)
        {
            //destroy shape
            Destroy(shape);
        }
        
    }

}
