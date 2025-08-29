using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool isRightPressed => Input.GetKey(KeyCode.RightArrow);
    public bool isLeftPressed => Input.GetKey(KeyCode.LeftArrow);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
