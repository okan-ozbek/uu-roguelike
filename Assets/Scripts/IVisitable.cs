public interface IVisitable
{
    public void Accept(IVisitor visitor);
}

public interface IActiveVisitable
{
    public void Accept(IActiveVisitor visitor);
}

public interface IPassiveVisitable
{
    public void Accept(IPassiveVisitor visitor);
}