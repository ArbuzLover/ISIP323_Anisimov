// -----------------------------------ИГРОКИ-------------------------------------------
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
//---------------------------------ВРАГИ------------------------
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

    public virtual void AttackPlayer(Player player)
    {
       
    }
}
//----------------------------БОССЫ--------------------------
public enum BossType
{
    VVG,
    Kovalevsky,
    ArchmageCPP,
    PestovCMinus
}
public class Boss : Enemy
{
    public BossType BossType { get; set; }

    public Boss(BossType type, int baseHealth, int baseAttack, int baseDefense)
        : base(GetEnemyTypeFromBoss(type), 0, 0, 0)
    {
        BossType = type;

        switch (type)
        {
            case BossType.VVG:
                Health = (int)(baseHealth * 2.0);
                Attack = (int)(baseAttack * 1.5);
                Defense = (int)(baseDefense * 1.2);
                break;

            case BossType.Kovalevsky:
                Health = (int)(baseHealth * 2.5);
                Attack = (int)(baseAttack * 1.3);
                Defense = (int)(baseDefense * 1.4);
                break;

            case BossType.ArchmageCPP:
                Health = (int)(baseHealth * 1.8);
                Attack = (int)(baseAttack * 1.6);
                Defense = (int)(baseDefense * 1.1);
                break;

            case BossType.PestovCMinus:
                Health = (int)(baseHealth * 1.3);
                Attack = (int)(baseAttack * 1.8);
                Defense = (int)(baseDefense * 0.6);
                break;
        }

        MaxHealth = Health;
    }

    private static EnemyType GetEnemyTypeFromBoss(BossType bossType)
    {
        switch (bossType)
        {
            case BossType.VVG:
                return EnemyType.Goblin;
            case BossType.Kovalevsky:
                return EnemyType.Skeleton;
            case BossType.ArchmageCPP:
                return EnemyType.Mage;
            case BossType.PestovCMinus:
                return EnemyType.Skeleton;
            default:
                return EnemyType.Goblin;
        }
    }

    public override void AttackPlayer(Player player)
    {
   
    }
}
