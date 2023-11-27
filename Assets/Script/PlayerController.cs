using UnityEngine;
using Yudiz.StackColor.UI;
namespace Yudiz.StackColor.GamePlay
{

    public class PlayerController : MonoBehaviour
    {
        #region PUBLIC_VARS
        public static System.Action<Color> Color;
        public static System.Action<float> Kick;
        public StackSpawner sp;
        #endregion

        #region PRIVATE_VARS
        [SerializeField] Rigidbody rb;
        [SerializeField] Color myColor;
        [SerializeField] Renderer[] myRend;

        [SerializeField] bool isPlaying;

        [SerializeField] bool isGameOver;
        [SerializeField] float forwardSpeed;
        [SerializeField] float sideSpeed;

        [SerializeField] Transform stackPosition;

        private Vector2 touchStartPos;
        private bool isDragging;
        bool isEnd;
        Transform parentPickup;
        Transform topmostPickup;

        [SerializeField] float forwardForce;
        [SerializeField] float forceAdder;
        [SerializeField] float forceReducer;
        public Transform playerTransform;
        public Vector3 initialPlayerPosition;

        #endregion

        #region UNITY_CALLBACKS
        private void Start()
        {
            ColorChange(myColor);   
        }

        void Update()
        {
          
            HandleInput();
           
        }
        void HandleInput()
        {
            if (isPlaying)
            {
                MoveForward();
                MoveSideways();
            }
            if (!isGameOver && Input.GetMouseButtonDown(0))
            {
                isPlaying = true;
                if (isEnd)
                {
                    forwardForce += forceAdder;
                }
               
            }
            if (isEnd)
            {
                forwardForce -= forceReducer * Time.deltaTime;
                if (forwardForce < 0) forwardForce = 0;
            }
        }
        #endregion

        #region STATIC_FUNCTIONS
        #endregion

        #region PUBLIC_FUNCTIONS
        #endregion

        #region PRIVATE_FUNCTIONS
        private void ColorChange(Color color)
        {
            myColor = color;
            for (int i = 0; i < myRend.Length; i++)
            {
                myRend[i].material.SetColor("_Color", myColor);
            }
        }

        void MoveForward()
        {
            rb.velocity = Vector3.forward * forwardSpeed;
        }
        void MoveSideways()
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStartPos = Input.mousePosition;
                isDragging = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                float deltaX = (Input.mousePosition.x - touchStartPos.x) * sideSpeed * Time.deltaTime;
                float newXPos = Mathf.Clamp(transform.position.x + deltaX, -3.5f, 3.5f);
                Vector3 newPosition = new Vector3(newXPos, transform.position.y, transform.position.z);
                rb.MovePosition(newPosition);
                touchStartPos = Input.mousePosition;
            }
           
        }

        void OnTriggerEnter(Collider other)
        {
            //for finish line start
            if (other.CompareTag("FinishLineStart"))
            {
                isEnd = true;

            }

            //for finish line end
            if (other.CompareTag("FinishLineEnd"))
            {
                rb.velocity = Vector3.zero;
                isPlaying = false;
                isGameOver = true;
                CameraController.instance.TurnCamera(Quaternion.Euler(20, -30, 0), 2);
                LaunchStack();

            }
            if (isEnd) return;

            //on enter to color wall
            if (other.CompareTag("ColorWall"))
            {
                ColorWall wallColor = other.GetComponent<ColorWall>();
                Color?.Invoke(wallColor.newColor);
                sp.StartSpawning();
            }

            //  For collecting cubes
            if (other.CompareTag("Pickup"))
            {
                Color pickupColor = other.GetComponent<Renderer>().material.color;

                if (ColorToHex(pickupColor) == ColorToHex(myColor))
                {
                    ScoreManager.instance.ScoreUpdate(other.GetComponent<PickupStackColor>().value);
                    other.GetComponent<PickupStackColor>().isCollectable = true;
                    CollectPickup(other.transform);
                }
                else
                {
                    RemoveFromStack();
                }
            }
        }
        private void OnEnable()
        {
            Color += ColorChange;
        }

        private void OnDisable()
        {
            Color -= ColorChange;
        }

        string ColorToHex(Color color)
        {
            return "#" +
                ((int)(color.r * 255)).ToString("X2") +
                ((int)(color.g * 255)).ToString("X2") +
                ((int)(color.b * 255)).ToString("X2") +     
                ((int)(color.a * 255)).ToString("X2");
        }

       
        void CollectPickup(Transform pickupTransform)
        {
               pickupTransform.GetComponent<Collider>().enabled = false;
                if (parentPickup == null)
                {
                    CreateNewStack(pickupTransform);
                }
                else
                {
                    AddToStack(pickupTransform);
                }
          
        }

        void CreateNewStack(Transform pickupTransform)
        {
            parentPickup = new GameObject("PickupStack").transform;
            parentPickup.position = stackPosition.position;
            parentPickup.parent = stackPosition;
            pickupTransform.SetParent(parentPickup);
            pickupTransform.localPosition = Vector3.zero;
        }

        void AddToStack(Transform pickupTransform)
        {
            float yOffset = parentPickup.childCount * pickupTransform.localScale.y;
            pickupTransform.SetParent(parentPickup);
            pickupTransform.localPosition = new Vector3(0f, yOffset, 0f);
        }


        void RemoveFromStack()
        {
            if (parentPickup != null && parentPickup.childCount > 0)
            {
                topmostPickup = parentPickup.GetChild(parentPickup.childCount - 1);
                Destroy(topmostPickup.gameObject);
            }
        }

        void LaunchStack()
        { 
            topmostPickup = GetTopmostPickup();

            Camera.main.GetComponent<CameraController>().SetTarget(topmostPickup);
          
            Kick(forwardForce);
        }

        Transform GetTopmostPickup()
        { 
                topmostPickup = parentPickup.GetChild(parentPickup.childCount - 1);
                return topmostPickup;       
        }

        public void ResetPlayer()
        {
            playerTransform.position = initialPlayerPosition;
        }
    }
}
#endregion

#region CO-ROUTINES
#endregion

#region EVENT_HANDLERS
#endregion

#region UI_CALLBACKS
#endregion
