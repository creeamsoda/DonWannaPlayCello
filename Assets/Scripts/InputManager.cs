using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool isRightPressed => Input.GetKey(KeyCode.RightArrow);
    public bool isLeftPressed => Input.GetKey(KeyCode.LeftArrow);
    public bool isUpPressed => Input.GetKey(KeyCode.UpArrow);
    public bool isDownPressed => Input.GetKey(KeyCode.DownArrow);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
