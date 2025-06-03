public interface IVisitor
{
    public void Visit(IVisitable visitable);
}

public interface IActiveVisitor
{
    public void Visit(IActiveVisitable visitable);
}

public interface IPassiveVisitor
{
    public void Visit(IPassiveVisitable visitable);
}