public interface IVisitable
{
    public void Accept(IVisitor visitor);
}

public interface IStatusEffectVisitable
{
    public void Accept(IStatusEffectVisitor visitor);
}

public interface IEffectVisitable
{
    public void Accept(IEffectVisitor visitor);
}