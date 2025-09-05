using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int Moving = Animator.StringToHash("IsMoving");
    [SerializeField] private Transform myTransform;
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private Animator myAnimator;
    [SerializeField] public SpriteRenderer mySpriteRenderer;

    [SerializeField] private SortingOrderManage sortingOrderManage;
    public Vector2 Pos => myTransform.position;

    public bool IsMoving => myRigidBody.linearVelocity.sqrMagnitude > 0.1f;
    [System.NonSerialized] public bool IsMoveable = false;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Parameters parameters;
    [SerializeField] private float movePower;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoveable) return;
        
        /*if (inputManager.isRightPressed && inputManager.isLeftPressed)
        {
            IsMoving = false;
            myAnimator.SetBool(Moving, false);
        }else if (inputManager.isRightPressed)
        {
            IsMoving = true;
            myAnimator.SetBool(Moving, true);
            //myTransform.position += Vector3.right * (parameters.PlayerSpeed * Time.deltaTime);
            myRigidBody.AddForce(Vector2.right * movePower);
        }
        else if (inputManager.isLeftPressed)
        {
            IsMoving  = true;
            myAnimator.SetBool(Moving, true);
            //myTransform.position += Vector3.left * (parameters.PlayerSpeed * Time.deltaTime);
            myRigidBody.AddForce(Vector2.left * movePower);
        }
        else
        {
            IsMoving = false;
            myAnimator.SetBool(Moving, false);
        }*/
        if (inputManager.isRightPressed)
        {
            //myTransform.position += Vector3.right * (parameters.PlayerSpeed * Time.deltaTime);
            myRigidBody.AddForce(Vector2.right * (movePower * 240 * Time.deltaTime));
        }
        if (inputManager.isLeftPressed)
        {
            //myTransform.position += Vector3.left * (parameters.PlayerSpeed * Time.deltaTime);
            myRigidBody.AddForce(Vector2.left * (movePower * 240 * Time.deltaTime));
        }

        if (inputManager.isUpPressed)
        {
            myRigidBody.AddForce(Vector2.up * (movePower * 240 * Time.deltaTime));
        }
        if (inputManager.isDownPressed)
        {
            myRigidBody.AddForce(Vector2.down * (movePower * 240 * Time.deltaTime));
        }
        myAnimator.SetBool(Moving, IsMoving);
        sortingOrderManage.ChangePlayerSortingOrder(this);
    }
}
