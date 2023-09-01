namespace RawDeal;

public abstract class Ability
{
    public abstract void Activate();
}

public class Maneuver:Ability
{
    public override void Activate()
    {
        throw new NotImplementedException();
    }
}


public class Action:Ability
{
    public override void Activate()
    {
        throw new NotImplementedException();
    }
}

public class Reversal:Ability
{
    public override void Activate()
    {
        throw new NotImplementedException();
    }
}

public class Card
{
    private string _title;
    private List<Ability> _types;
    private List<string> _subtypes;
    private int _fortitude;
    private string _effect;
    private int _damage;


    public Card(CardInfo cardData)
    {
        this._title = cardData.Title;
        this._types = AbilitySorter(cardData.Types);
        this._subtypes = cardData.Subtypes;
        this._fortitude = Int32.Parse(cardData.Fortitude);
        this._effect = cardData.CardEffect;
        this._damage = DamageCalculator(cardData.Damage);
    }
    private List<Ability> AbilitySorter(List<string> types)
    {
        List<Ability> typesList = new List<Ability>();
        foreach (string type in types)
        {
            if (type == "Maneuver")
            {
                typesList.Add(new Maneuver());
            }
            else if (type == "Action")
            {
                typesList.Add(new Action());
            }
            else if (type == "Reversal")
            {
                typesList.Add(new Reversal());
            }
        }
        return typesList;
    }
    
    private int DamageCalculator(string damage)
    {
        if (damage == "#")
        {
            return 0;
        }
        else
        {
            return Int32.Parse(damage);
        }

        return 0;
    }

    public string Title
    {
        get { return _title; }
    }

    public List<Ability> Types
    {
        get { return _types;  }
    }

    public List<string> SubTypes
    {
        get { return _subtypes; }
    }

    public int Fortitude
    {
        get { return _fortitude; }
    }

    public string Effect
    {
        get { return _effect; }
    }

    public int Damage
    {
        get { return _damage; }
    }
}