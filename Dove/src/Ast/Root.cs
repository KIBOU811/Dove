using System.Collections.Generic;
using System.Linq;

namespace Dove.Ast
{
    public class Root : INode
    {
        public List<IStatement> Statements { get; set; }

        public string TokenLiteral()
        {
            return this.Statements.FirstOrDefault()?.TokenLiteral() ?? "";
        }
    }
}