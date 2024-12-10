using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private void Init()
    {
        playerController.Init();
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
