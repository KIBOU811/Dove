using Dove.Lexing;

namespace Dove.Ast.Statements
{
    public class ExpressionStatement : IStatement
    {
        public Token Token { get; set; } // first token of statement
        public IExpression Expression { get; set; }

        public string ToCode() => this.Expression?.ToCode() ?? "";

        public string TokenLiteral() => this.Token.Literal;
    }
}