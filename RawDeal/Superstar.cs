namespace RawDeal;

public class SuperstarInfo
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public int HandSize { get; set; }
    public int SuperstarValue { get; set; }
    public string SuperstarAbility { get; set; }
}

public class Superstar
{
    private string _name;
    private string _logo;
    private int _handSize;
    private int _superstarValue;
    private string _superstarAbility;

    public Superstar(SuperstarInfo info)
    {
        _name = info.Name;
        _logo = info.Logo;
        _handSize = info.HandSize;
        _superstarValue = info.SuperstarValue;
        _superstarAbility = info.SuperstarAbility;
    }

    public string Name
    {
        get { return _name; }
    }

    public string Logo
    {
        get { return _logo; }
    }

    public int HandSize
    {
        get { return _handSize; }
    }

    public int SuperstarValue
    {
        get { return _superstarValue; }
    }

    public string SuperstarAbility
    {
        get { return _superstarAbility; }
    }
}