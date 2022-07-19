using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularEditorScript : MonoBehaviour
{
    //Editable modular objects
    [SerializeField]
    Transform[] modularPrefabs;

    List<Transform> menuShapes;

    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        //Initalise attributes
        menuShapes = new List<Transform>();

        //DisplayNewShapeGrid(4);
    }

    // Update is called once per frame
    void Update()
    {
        

        //If Mouse is clicked
        MouseClick();

    }

    void MouseClick()
    {
        //Left Mouse Button
        if (Input.GetButtonDown("Fire1"))
        {
            //Deselect


            Vector3 mousePosition = Input.mousePosition;

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
        //Get shape script
        selectedObject.GetComponent<ModularShapeScript>().NewShape(chosenShape.transform);

        //Pass through shape
        //selectedObject.NewShape(chosenShape.transform);

    }

    void DeleteShape()
    {

        //Get shape script
        selectedObject.GetComponent<ModularShapeScript>().DeleteShape();

        //Call delete
        //selectedObject.DeleteShape();

        selectedObject = null;//Object Deselect

    }

    public void SelectObject(GameObject selected)
    {
        selectedObject = selected;


    }

    void SelectNewShape()
    {
        //Get region mouse clicked


        //Close Menu
        CloseNewShapeGrid();
        
        //Add shape to object

    }

    void ShapeOnCamera(Transform prefab, Vector3 position)
    {
        //Create object
        Transform cameraShape = Instantiate(prefab);

        //Parent to camera
        cameraShape.transform.SetParent(Camera.main.transform, false);

        //Apply transform to object
        cameraShape.transform.localPosition = position;

        //Add to list
        menuShapes.Add(cameraShape);
    }

    void DisplayNewShapeGrid(int gridWidth)
    {


        Vector3 position = Vector3.forward;

        int xIndex, yIndex;
        xIndex = yIndex = 0;

        foreach(Transform shape in modularPrefabs)
        {
            //for next shape

            //Attach to camera
            ShapeOnCamera(shape, new Vector3(xIndex,yIndex,1f));
        
            xIndex++;//Increment X position

            //If off the end of menu wrap to next row
            if(xIndex > gridWidth)
            {
                xIndex = 0;
                yIndex++;
            }
        }

        //

    }

    void CloseNewShapeGrid()
    {
        //For each shape in menu
        foreach (Transform shape in menuShapes)
        {
            //destroy shape
            Destroy(shape);
        }
        
    }

    //GUI
    private void OnGUI()
    {
        //Creation Menu
        CreationMenu(5, 5);

        //Edit Menu
        EditMenu(5, 200);

        //Toolpanel
        ToolMenu(5, 400);
    }

    private void CreationMenu(int xPosition, int yPosition)
    {
        //Menu Dimentions
        int width = 80;
        int height = 70;

        //Background box
        GUI.Box (new Rect (xPosition, yPosition, width, height), "Creation");

        //New Shape button
        if ( GUI.Button(new Rect (xPosition, yPosition + 20, width, 20), "New" ) )
        {
            //Open new shape menu
            DisplayNewShapeGrid(4);
        }

        //Delete Shape button 
        if ( GUI.Button(new Rect (xPosition, yPosition + 45, width, 20), "Delete" ) )
        {
            //Delete 
            DeleteShape();
        }

    }

    private void EditMenu(int xPosition, int yPosition)
    {
        //Menu Dimentions
        int width = 100;
        int height = 145;

        //if an object is selected
        if ( selectedObject != null )
        {

            //Background box
            GUI.Box (new Rect (xPosition, yPosition, width, height), "Edit");

            //Position
            GUI.Label(new Rect (xPosition + 5, yPosition + 20, width, 20), "Position" );

            selectedObject.transform.localPosition = new Vector3(
            float.Parse(GUI.TextField(new Rect (xPosition + 5, yPosition + 40, 30, 20), ("" + selectedObject.transform.localPosition.x) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 35, yPosition + 40, 30, 20), ("" + selectedObject.transform.localPosition.y) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 65, yPosition + 40, 30, 20), ("" + selectedObject.transform.localPosition.z) ) )
            );

            //Rotation
            GUI.Label(new Rect (xPosition + 5, yPosition + 60, width, 20), "Rotation" );

            selectedObject.transform.localRotation = Quaternion.Euler(
            float.Parse(GUI.TextField(new Rect (xPosition + 5, yPosition + 80, 30, 20), ("" + selectedObject.transform.localRotation.x) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 35, yPosition + 80, 30, 20), ("" + selectedObject.transform.localRotation.y) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 65, yPosition + 80, 30, 20), ("" + selectedObject.transform.localRotation.z) ) )
            );

            //Scale 
            GUI.Label(new Rect (xPosition + 5, yPosition + 100, width, 20), "Scale" );

            selectedObject.transform.localScale = new Vector3(
            float.Parse(GUI.TextField(new Rect (xPosition + 5, yPosition + 120, 30, 20), ("" + selectedObject.transform.localScale.x) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 35, yPosition + 120, 30, 20), ("" + selectedObject.transform.localScale.y) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 65, yPosition + 120, 30, 20), ("" + selectedObject.transform.localScale.z) ) )
            );

        }
    }

    private void ToolMenu(int xPosition, int yPosition)
    {
        //Menu Dimentions
        int width = 80;
        int height = 100;

        //Background box
        GUI.Box (new Rect (xPosition, yPosition, width, height), "Tools");

        //Move tool
        if ( GUI.Button(new Rect (xPosition, yPosition + 20, width, 20), "Move" ) )
        {
            //Set Tool to move

        }

        //Rotate tool
        if ( GUI.Button(new Rect (xPosition, yPosition + 45, width, 20), "Rotate" ) )
        {
            //Set Tool to rotate
            
        }

        //Scale tool
        if ( GUI.Button(new Rect (xPosition, yPosition + 70, width, 20), "Scale" ) )
        {
            //Set Tool to scale
            
        }

    }

}
