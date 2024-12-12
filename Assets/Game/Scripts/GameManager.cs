using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    
    [SerializeField] private PlayerController playerController;

    public int kill = 0;
    private void Awake()
    {
        instance = this;
    }
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
