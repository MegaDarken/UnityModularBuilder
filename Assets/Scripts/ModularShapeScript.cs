using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularShapeScript : MonoBehaviour
{
    //Vector of last mouse position
    private Vector3 previousPosition;
    private Vector3 previousRotation;
    private Vector3 previousScale;

    private Vector3 previousMousePosition;
    
    ModularEditorScript editorScript;

    // Start is called before the first frame update
    void Start()
    {
        //Get Editor Object
        GameObject editorObject = GameObject.FindWithTag("ModularEditor");

        editorScript = editorObject.GetComponent<ModularEditorScript>();
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
        previousRotation = gameObject.transform.eulerAngles;
        previousScale = gameObject.transform.localScale;

        previousMousePosition = MouseVector();

        //Select object
        SelectShape();
    }

    private void OnMouseDrag()
    {
        //find distance from previous position
        //Move selected object
        switch (editorScript.CurrentTool())
        {
            case ModularEditorScript.MOVE_TOOL_VALUE:
                gameObject.transform.position = previousPosition + (MouseVector() - previousMousePosition);
                break;

            case ModularEditorScript.ROTATE_TOOL_VALUE:
                gameObject.transform.eulerAngles = previousRotation + (MouseVector() - previousMousePosition);
                break;

            case ModularEditorScript.SCALE_TOOL_VALUE:
                gameObject.transform.localScale = previousScale + (MouseVector() - previousMousePosition);
                break;

            default:
                Debug.Log("No tool selected.");
                break;
        }

    }

    private Vector3 MouseVector()
    {
        //Get dimention position
        Vector3 mousePosition = Input.mousePosition;

        //set Z to Distance between camera and object
        mousePosition.z = Vector3.Distance(Camera.main.transform.position, previousPosition);

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    
    void SelectShape()
    {
        
        //If there is an editor and new shape menu is not open
        if ( editorScript != null )
        {
            
            if (!editorScript.NewShapeMenuIsOpen())
            {
                //Get Script
                editorScript.SelectObject(gameObject);//Pass reference for this object into ModularEditorScript
            }
            else if (editorScript.NewShapeMenuIsOpen())
            {
                //Create new instance of object clicked
                editorScript.NewShape(gameObject);
            }
            
        }
    }


    public void DeleteShape()
    {
        //Delete object
        Destroy(gameObject);

    }

}
