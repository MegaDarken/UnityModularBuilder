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

        //Pass through shape
        //selectedObject.NewShape(chosenShape.transform);

    }

    void DeleteShape()
    {

        //Get shape script

        //Call delete
        //selectedObject.DeleteShape();

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
        int height = 100;

        //Background box
        GUI.Box (new Rect (xPosition, yPosition, width, height), "Creation");

        //New Shape button

        //Delete Shape button 

    }

    private void EditMenu(int xPosition, int yPosition)
    {
        //Menu Dimentions
        int width = 80;
        int height = 100;

        //if selection is not null

        //Background box
        GUI.Box (new Rect (xPosition, yPosition, width, height), "Edit");

        //Position

        //Rotation

        //Scale 

    }

    private void ToolMenu(int xPosition, int yPosition)
    {
        //Menu Dimentions
        int width = 80;
        int height = 100;

        //Background box
        GUI.Box (new Rect (xPosition, yPosition, width, height), "Tools");

        //Move tool

        //Rotate tool

        //Scale tool

    }

}
