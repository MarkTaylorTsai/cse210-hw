public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus
    ) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus,
        int amountCompleted
    ) : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted}";
    }
}