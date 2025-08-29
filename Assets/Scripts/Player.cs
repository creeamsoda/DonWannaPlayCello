using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int Moving = Animator.StringToHash("IsMoving");
    [SerializeField] private Transform myTransform;
    [SerializeField] private Animator myAnimator;
    public Vector2 Pos => myTransform.position;

    [System.NonSerialized] public bool IsMoving = false;
    [System.NonSerialized] public bool IsMoveable = false;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Parameters parameters;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoveable) return;
        
        if (inputManager.isRightPressed && inputManager.isLeftPressed)
        {
            IsMoving = false;
            myAnimator.SetBool(Moving, false);
        }else if (inputManager.isRightPressed)
        {
            IsMoving = true;
            myAnimator.SetBool(Moving, true);
            myTransform.position += Vector3.right * (parameters.PlayerSpeed * Time.deltaTime);
        }
        else if (inputManager.isLeftPressed)
        {
            IsMoving  = true;
            myAnimator.SetBool(Moving, true);
            myTransform.position += Vector3.left * (parameters.PlayerSpeed * Time.deltaTime);
        }
        else
        {
            IsMoving = false;
            myAnimator.SetBool(Moving, false);
        }
    }
}
