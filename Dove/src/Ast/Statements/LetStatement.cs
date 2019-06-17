using Dove.Ast;
using Dove.Ast.Expressions;
using Dove.Lexing;

namespace Dove.Ast.Statements
{
    public class LetStatement : IStatement
    {
        public Token Token { get; set; }
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public string TokenLiteral() => this.Token.Literal;
    }
}