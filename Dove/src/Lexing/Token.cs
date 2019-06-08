using System.Collections.Generic;

namespace Dove.Lexing
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }

        public static Dictionary<string, TokenType> Keywords
            = new Dictionary<string, TokenType>() {
            { "let", TokenType.LET },
            { "fn", TokenType.FUNCTION },
        };

        public Token(TokenType type, string literal)
        {
            this.Type = type;
            this.Literal = literal;
        }

        public static TokenType LookupIdentifier(string identifier)
        {
            if (Token.Keywords.ContainsKey(identifier))
            {
                return Keywords[identifier];
            }
            return TokenType.IDENT;
        }
    }

    public enum TokenType
    {
        // wrong Token, End of File
        ILLEGAL,
        EOF,

        // identifier, literal of integer
        IDENT,
        INT,

        // operator
        ASSIGN,
        PLUS,
        MINUS,
        ASTERISK,
        SLASH,
        NEGATION,
        LT,
        GT,
        EQ,
        NOT_EQ,

        // delimiter
        COMMA,
        SEMICOLON,

        // paren (){}
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,

        // reserved word
        FUNCTION,
        LET,

        // and more...
    }
}