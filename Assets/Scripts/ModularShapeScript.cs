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

        //set Z to Distance between camera and object
        mousePosition.z = Vector3.Distance(Camera.main.transform.position, previousPosition);

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    
    void SelectShape()
    {
        //Get Editor Object
        GameObject editorObject = GameObject.FindWithTag("ModularEditor");

        ModularEditorScript editorScript;

        //If there is an editor and new shape menu is not open
        if (( editorScript = editorObject.GetComponent<ModularEditorScript>()) != null )
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

    public void NewShape(Transform prefab)
    {
        //Create shape
        Transform newShape = Instantiate(prefab);

        //Set parent to root as this object
        newShape.transform.SetParent(gameObject.transform, false);

    }

    public void DeleteShape()
    {
        //Delete object
        Destroy(gameObject);

    }

}
