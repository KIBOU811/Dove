using System.Collections.Generic;
using Dove.Ast;
using Dove.Ast.Expressions;
using Dove.Ast.Statements;
using Dove.Lexing;

namespace Dove.Parsing
{
    public class Parser
    {
        public Token CurrentToken { get; set; }
        public Token NextToken { get; set; }
        public Lexer Lexer { get; }

        public List<string> Errors { get; set; } = new List<string>();

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

        public Root ParseProgram()
        {
            var root = new Root();
            root.Statements = new List<IStatement>();

            while (this.CurrentToken.Type != TokenType.EOF)
            {
                var statement = this.ParseStatement();
                if (statement != null)
                {
                    root.Statements.Add(statement);
                }
                this.ReadToken();
            }
            return root;
        }

        public IStatement ParseStatement()
        {
            switch (this.CurrentToken.Type)
            {
                case TokenType.LET:
                    return this.ParseLetStatement();
                case TokenType.RETURN:
                    return this.ParseReturnStatement();
                default:
                    return null;
            }
        }

        public LetStatement ParseLetStatement()
        {
            var statement = new LetStatement();
            // this.CurrentToken.Literal is "let"
            statement.Token = this.CurrentToken;

            if (!this.ExpectPeek(TokenType.IDENT)) return null;

            // identifier (left side of let statement)
            statement.Name = new Identifier(this.CurrentToken, this.CurrentToken.Literal);

            // assign '='
            if (!this.ExpectPeek(TokenType.ASSIGN)) return null;

            // statement (right side of let statement)
            // TODO: will be implemented later
            while (this.CurrentToken.Type != TokenType.SEMICOLON)
            {
                // until semicolon is found
                this.ReadToken();
            }

            return statement;
        }
        
        public ReturnStatement ParseReturnStatement()
        {
            var statement = new ReturnStatement();
            // this.CurrentToken.Literal is "return"
            statement.Token = this.CurrentToken;
            this.ReadToken();

            // TODO: will be implemented later
            while (this.CurrentToken.Type != TokenType.SEMICOLON)
            {
                // until semicoron is found
                this.ReadToken();
            }

            return statement;
        }

        private bool ExpectPeek(TokenType type)
        {
            // if next token is expected, return true
            // 次のトークンが期待するものであれば読み飛ばす
            if (this.NextToken.Type == type)
            {
                this.ReadToken();
                return true;
            }

            this.AddNextTokenError(type, this.NextToken.Type);
            return false;
        }

        private void AddNextTokenError(TokenType expected, TokenType actual)
        {
            this.Errors.Add($"Actual: {actual.ToString()}{System.Environment.NewLine}Expexted: {expected.ToString()}");
        }
    }
}