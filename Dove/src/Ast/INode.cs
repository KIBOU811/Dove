namespace Dove.Ast
{
    public interface INode
    {
        string TokenLiteral();
        string ToCode();
    }
}