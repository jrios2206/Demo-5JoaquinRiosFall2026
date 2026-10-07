using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class SelectionManager : MonoBehaviour
{
    public Vector2 mousePos;
    private Ray _raySelector;
    public NavMeshAgent unitSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) // making sure left click is being click
        {
            mousePos = Mouse.current.position.ReadValue(); // turning the left clikc into x,y
            _raySelector = Camera.main.ScreenPointToRay(mousePos); // invisible laser from camera 
            if (Physics.Raycast(_raySelector, out RaycastHit hit)) // making sure our laser hits somethig
            {
                Debug.Log(hit.transform.name); // if yes the name of the any object
                if (hit.transform.CompareTag("Unit")) // if yes itll give us the tag name
                {
                    unitSelected = hit.transform.GetComponent<NavMeshAgent>(); // unitselected will use the meshagent to move
                    Debug.Log("selected " +  hit.transform.name); // debug to make sure if this thing works
                    unitSelected.GetComponent<Renderer>().material.color = Color.green; // unit will change to green 
                }
            }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame) // making sure if right click is being used
        {
            mousePos = Mouse.current.position.ReadValue(); // reading value to x and y 
            _raySelector = Camera.main.ScreenPointToRay(mousePos); // invisible laser
            if (Physics.Raycast(_raySelector, out RaycastHit hit)) // making sure that we hit somthing 
            {
                if (unitSelected != null)// if it isnt empty  object will move 
                {
                    unitSelected.SetDestination(hit.point);
                }
            }
        }
    }
}
