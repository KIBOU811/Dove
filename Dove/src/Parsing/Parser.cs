using Dove.Ast;
using Dove.Lexing;

namespace Dove.Parsing
{
    public class Parser
    {
        public Token CurrentToken { get; set; }
        public Token NextToken { get; set; }
        public Lexer Lexer { get; }

        public Parser(Lexer lexer)
        {
            this.Lexer = lexer;

            // Read two tokens
            this.CurrentToken = this.Lexer.NextToken();
            this.NextToken = this.Lexer.NextToken();
        }

        private void ReadToken()
        {
            this.CurrentToken = this.NextToken;
            this.NextToken = this.Lexer.NextToken();
        }

        public Root ParseRoot()
        {
            return null;
        }
    }
}