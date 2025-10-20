public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}

public class Armor
{
    public string Name { get; set; }
    public double Defense { get; set; }

    public Armor(string name, double defense)
    {
        Name = name;
        Defense = defense;
    }
}

public class Player
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public Weapon CurrentWeapon { get; set; }
    public Armor CurrentArmor { get; set; }
    public bool IsFrozen { get; set; }
    public bool IsDefending { get; set; }

    public Player()
    {
        MaxHealth = 100;
        Health = MaxHealth;
        CurrentWeapon = new Weapon("Кинжал", 5);
        CurrentArmor = new Armor("Кожаный доспех", 0.7);
        IsDefending = false;
    }

    public void TakeDamage(Enemy attacker)
    {

    }
    public void Heal()
    {
        Health = MaxHealth;
        Console.WriteLine("❤️ Ваше здоровье полностью восстановлено!");
    }
    public void Defend()
    {
        IsDefending = true;
    }

    public void Attack(Enemy enemy)
    {
        
    }

}

public enum EnemyType
{
    Goblin,
    Skeleton,
    Mage
}

public class Enemy
{
    public EnemyType Type { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Enemy(EnemyType type, int health, int attack, int defense)
    {
        Type = type;
        Health = health;
        MaxHealth = health;
        Attack = attack;
        Defense = defense;
    }

    public void TakeDamage(Player player)
    {

    }

    public void AttackPlayer(Player player)
    {
       
    }
}



}