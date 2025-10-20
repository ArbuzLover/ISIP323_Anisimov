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


//-------------------------------------------ИГРА-------------------------------------------

public class Game
{
    private Player player;
    private Random random;
    private int Count;
    private List<Weapon> weapons;
    private List<Armor> armors;

    public Game()
    {
        player = new Player();
        random = new Random();
        Count = 0;
        
    }

    

    public void StartGame()
    {
        Console.WriteLine("Добро пожаловать в игру!");
        Console.WriteLine("Сражайтесь с врагами, находите сокровища и выживайте!\n");

        while (player.Health > 0)
        {
            Play();
        }

        GameOver();
    }

    private void Play()
    {
        Count++;
        PrintPlayerStatus();

        if (player.IsFrozen)
        {
            FrozenCheck();
            return;
        }

        ShowMenu();
    }

    private void PrintPlayerStatus()
    {

    }

    private void FrozenCheck()
    {
        Console.WriteLine("❄️ Вы заморожены и пропускаете ход!");
        player.IsFrozen = false;
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n1. Продолжить путешествие");
        Console.WriteLine("2. Выйти из игры");

        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                ProcessTurn();
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Неверный ввод!");
                ShowMenu();
                break;
        }
    }

    private void ProcessTurn()
    {
        if (Count % 10 == 0) // каждыу 10 ходов босс
        {
            FindBoss();
        }
        else
        {
            if (random.NextDouble() < 0.5) // 50% шанс на врага или сундук
            {
                FindEnemy();
            }
            else
            {
                FindChest();
            }
        }
    }

    private void FindEnemy()
    {

    }

    private Enemy CreateEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Goblin: return new Enemy(EnemyType.Goblin, 30, 8, 5);
            case EnemyType.Skeleton: return new Enemy(EnemyType.Skeleton, 25, 10, 3);
            case EnemyType.Mage: return new Enemy(EnemyType.Mage, 20, 12, 1);
            default: return new Enemy(EnemyType.Goblin,30, 8, 5);
        }
    }

    private void PrintEnemyInfo(Enemy enemy)
    {
        Console.WriteLine($"❤ Здоровье врага: {enemy.Health} |  Атака: {enemy.Attack} |  Защита: {enemy.Defense}");
    }

    private void FindBoss()
    {

    }

    private Boss CreateBoss(BossType type)
    {
        switch(type)
        {
            case BossType.VVG: return new Boss(BossType.VVG, 40, 10, 3);
            case BossType.Kovalevsky: return new Boss(BossType.Kovalevsky, 35, 12, 4);
            case BossType.ArchmageCPP: return new Boss(BossType.ArchmageCPP, 25, 15, 2);
            case BossType.PestovCMinus: return new Boss(BossType.PestovCMinus, 20, 18, 1);
            default: return new Boss(BossType.VVG, 40, 10, 3);
        }
    }

    private void Combat(Enemy enemy)
    {

    }

    private void ShowCombatMenu()
    {
        Console.WriteLine("\n1. Атаковать");
        Console.WriteLine("2. Защищаться");
    }

    private void FindChest()
    {
        Console.WriteLine("\n Вы нашли сундук!");

        var chestType = random.Next(0, 3);

        switch (chestType)
        {
            case 0:
                GiveHealing();
                break;
            case 1:
                GiveWeapon();
                break;
            case 2:
                GiveArmor();
                break;
        }
    }

    private void GiveHealing()
    {
        Console.WriteLine(" В сундуке лечебное зелье!");
        player.Heal();
    }

    private void GiveWeapon()
    {

    }

    private void GiveArmor()
    {

    }

    private void GameOver()
    {

    }
}