public interface IVisitor
{
    public void Visit(IVisitable visitable);
}

public interface IStatusEffectVisitor
{
    public void Visit(IStatusEffectVisitor visitable);
}

public interface IEffectVisitor
{
    public void Visit(IEffectVisitable visitable);
}