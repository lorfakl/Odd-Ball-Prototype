using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Utilities.Events;

public class BallObject : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameEvent objSelectedEvent;

    Vector3 _homePosition;
    // Start is called before the first frame update
    public BallInfo CurrentBallInfo { get; private set; }
    public SpriteRenderer Image { get { return spriteRenderer; } }
    public Vector3 InitialPosition
    {
        get { return _homePosition; }
    }

    public void GetNext()
    {
        HelperFunctions.Log("Ball Data Changed");
        BallInfo b = BallHandler.DeQueue();
        CurrentBallInfo = b;
        Image.sprite = b.Image;
    }

    private void Awake()
    {
        _homePosition = transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        HelperFunctions.Log("Pressed");
        objSelectedEvent.Raise();
    }

    
    
}
