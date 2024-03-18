using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Variables
    [Header("Player")]
    public GameObject player;
    public Vector3 playerPosition;
    [Header("Camera")]
    public GameObject cameraFollowingPlayer;
    public Vector3 cameraPosition;
    public Vector2 minimum;
    public Vector2 maximum;
    public float smoothing;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;

        cameraFollowingPlayer = GameObject.Find("Main Camera").gameObject;
        cameraPosition = cameraFollowingPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ShowPlayerPosition();
        ShowCameraPosition();

        FollowTarget();
    }

    // Functions
    private void ShowPlayerPosition()
    {
        playerPosition = player.transform.position;
    }
    
    private void ShowCameraPosition()
    {
        cameraPosition = cameraFollowingPlayer.transform.position;
    }

    private void FollowTarget()
    {
        Vector2 camera = new Vector2(transform.position.x, transform.position.y);
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);

        float posX = Mathf.SmoothDamp(camera.x, target.x, ref velocity.x, smoothing);
        float posY = Mathf.SmoothDamp(camera.y, target.y, ref velocity.x, smoothing);

        cameraFollowingPlayer.transform.position = new Vector3(Mathf.Clamp(posX, minimum.x, maximum.x), Mathf.Clamp(posY, minimum.y, maximum.y), cameraFollowingPlayer.transform.position.z);
    }
}
