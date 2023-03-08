using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    
    private static DatabaseManager instance = null;
    public static DatabaseManager Instance => instance;

    public WeaponData WeaponData => weaponData;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
