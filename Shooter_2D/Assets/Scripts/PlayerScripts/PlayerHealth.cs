
public class PlayerHealth : Health
{
    private float _maxHealth;
    public HUDManager _hudManager;
    private void Start()
    {
        _maxHealth = _health;
    }

    private void Update()
    {
        _hudManager.HealthOfHero(_health, _maxHealth);
    }
}
