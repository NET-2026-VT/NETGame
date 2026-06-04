using SimpleConsoleGame.GameWorld;
using System.Diagnostics.CodeAnalysis;

internal abstract class Creature : IDrawable
{
    private Cell _cell;
    private int _health;
    private ConsoleColor _color;
    private string _name;

    public string Symbol { get; }
    public int MaxHealth { get; }
    public int Damage { get; protected set; } = 50;
    public bool IsDead => _health <= 0;
    public ConsoleColor Color
    {
        get => IsDead ? ConsoleColor.Gray : _color;
        protected set => _color = value;
    }

    public int Health
    {
        get => _health;
        private set => _health = value >= MaxHealth ? MaxHealth : value;
    }
    public Cell Cell
    {
        get => _cell;
        [MemberNotNull(nameof(_cell))]
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _cell = value;
        }
    }

    public static Action<string>? AddToLog { get; set; }

    //public Cell Cell
    //{
    //    get => field;

    //    set
    //    {
    //        ArgumentNullException.ThrowIfNull(value, nameof(value));
    //        field = value;
    //    }

    //}
    public Creature(Cell cell, string symbol, int maxHealth = 50)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        Cell = cell;
        Symbol = symbol;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Color = ConsoleColor.Green;
        _name = GetType().Name;
    }

    internal void Attack(Creature target)
    {
        if (target.IsDead || this.IsDead) return;

        target.Health -= this.Damage;

        AddToLog?.Invoke($"The {this._name} attacks the {target._name} for {this.Damage}");

        if (target.IsDead)
            AddToLog?.Invoke($"The {target._name} is dead");
    }
}