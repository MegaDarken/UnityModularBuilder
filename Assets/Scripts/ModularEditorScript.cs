using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularEditorScript : MonoBehaviour
{
    //Editable modular objects
    [SerializeField]
    GameObject[] modularPrefabs;

    List<Transform> menuShapes;

    private GameObject selectedObject;

    private bool newShapeMenuIsOpen; 

    private int gridWidth = 4;
    private float gridSelectionSize = 0.2f;
    private Vector3 newShapeMenuPosition;

    private byte currentTool = 0;
    public const byte MOVE_TOOL_VALUE = 0;
    public const byte ROTATE_TOOL_VALUE = 1;
    public const byte SCALE_TOOL_VALUE = 2;

    // Start is called before the first frame update
    void Start()
    {
        //Initalise attributes
        menuShapes = new List<Transform>();

        newShapeMenuIsOpen = false;

        newShapeMenuPosition = new Vector3(0.3f, 0.3f, 1f);
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


            

            //If in selection Menu, pass to new shape selection
            if (newShapeMenuIsOpen)//And within space?
            {
                //SelectNewShape();
                CloseNewShapeGrid();
            }

            //Else if clicked button(s)

            //Else select an object or nothing

        }

        //Right Mouse Button

    }

    public void NewShape(GameObject chosenShape)
    {
        //Create shape
        Transform newShape = Instantiate(chosenShape.transform);

        //New shape is placed above selected one
        newShape.transform.localPosition = Vector3.up;
        newShape.transform.localScale = Vector3.one;//Normal scale

        //Set parent to root as this object
        newShape.transform.SetParent(selectedObject.transform, false);

        
    }

    void DeleteShape(GameObject shape)
    {

        //Get shape script
        shape.GetComponent<ModularShapeScript>().DeleteShape();

        shape = null;//Object Deselect

    }

    public void SelectObject(GameObject selected)
    {
        selectedObject = selected;


    }

    public bool NewShapeMenuIsOpen()
    {
        return newShapeMenuIsOpen;
    }

    void ShapeOnCamera(GameObject prefab, Vector3 position, Vector3 scale)
    {
        //Create object
        Transform cameraShape = Instantiate(prefab.transform);

        //Parent to camera
        cameraShape.transform.SetParent(Camera.main.transform, false);

        //Apply transform to object
        cameraShape.transform.localPosition = position;
        cameraShape.transform.localScale = scale;

        //Add to list
        menuShapes.Add(cameraShape);
    }

    void DisplayNewShapeGrid()
    {

        int xIndex, yIndex;
        xIndex = yIndex = 0;

        foreach(GameObject shape in modularPrefabs)
        {
            //for next shape

            //Attach to camera
            ShapeOnCamera(shape, newShapeMenuPosition + new Vector3(xIndex * gridSelectionSize,-yIndex * gridSelectionSize, 0f), new Vector3(0.1f, 0.1f, 0.1f));
        
            xIndex++;//Increment X position

            //If off the end of menu wrap to next row
            if(xIndex >= gridWidth)
            {
                xIndex = 0;
                yIndex++;
            }
        }

        //Flag that the menu is open
        newShapeMenuIsOpen = true;
    }

    void CloseNewShapeGrid()
    {

        //For each shape in menu
        foreach (Transform shape in menuShapes)
        {
            
            //destroy shape
            DeleteShape(shape.gameObject);
        }

        menuShapes.Clear();
        
        newShapeMenuIsOpen = false;
    }

    public int CurrentTool()
    {
        return currentTool;
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

        //New Shape Menu Title
        NewShapeMenu();
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
            //Is the menu already open?
            if ( newShapeMenuIsOpen )
            {
                //Close menu
                CloseNewShapeGrid();
            }
            else
            {
                //Open new shape menu
                DisplayNewShapeGrid();
            }
        }

        //Delete Shape button 
        if ( GUI.Button(new Rect (xPosition, yPosition + 45, width, 20), "Delete" ) )
        {
            //Delete 
            DeleteShape(selectedObject);
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

            selectedObject.transform.localEulerAngles = new Vector3(
            float.Parse(GUI.TextField(new Rect (xPosition + 5, yPosition + 80, 30, 20), ("" + selectedObject.transform.localEulerAngles.x) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 35, yPosition + 80, 30, 20), ("" + selectedObject.transform.localEulerAngles.y) ) ),
            float.Parse(GUI.TextField(new Rect (xPosition + 65, yPosition + 80, 30, 20), ("" + selectedObject.transform.localEulerAngles.z) ) )
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
            currentTool = MOVE_TOOL_VALUE;
        }

        //Rotate tool
        if ( GUI.Button(new Rect (xPosition, yPosition + 45, width, 20), "Rotate" ) )
        {
            //Set Tool to rotate
            currentTool = ROTATE_TOOL_VALUE;
        }

        //Scale tool
        if ( GUI.Button(new Rect (xPosition, yPosition + 70, width, 20), "Scale" ) )
        {
            //Set Tool to scale
            currentTool = SCALE_TOOL_VALUE;
        }

    }

    private void NewShapeMenu()
    {
        //Only show if menu is open 
        if (NewShapeMenuIsOpen())
        {
            //Title Displayed Shapes
            int xPosition = (int)(Screen.width * 0.5f) + 100;
            int yPosition = 5;

            int width = 400;
            int height = 30;

            GUI.Box (new Rect (xPosition, yPosition, width, height), "New Shapes (You can clone existing shapes in the scene.)");
        }
    }

}
