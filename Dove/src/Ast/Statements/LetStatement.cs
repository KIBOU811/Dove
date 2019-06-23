using Dove.Ast;
using Dove.Ast.Expressions;
using Dove.Lexing;
using System.Text;

namespace Dove.Ast.Statements
{
    public class LetStatement : IStatement
    {
        public Token Token { get; set; }
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public string TokenLiteral() => this.Token.Literal;

        public string ToCode()
        {
            var builder = new StringBuilder();
            builder.Append(this.Token?.Literal ?? "");
            builder.Append(" ");
            builder.Append(this.Name?.ToCode() ?? "");
            builder.Append(" = ");
            builder.Append(this.Value?.ToCode() ?? "");
            builder.Append(";");
            return builder.ToString();
        }
    }
}