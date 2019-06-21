using System.Collections.Generic;

namespace Dove.Lexing
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }

        public static Dictionary<string, TokenType> Keywords
            = new Dictionary<string, TokenType>() {
            { "fn", TokenType.FUNCTION },
            { "let", TokenType.LET },
            { "if", TokenType.IF },
            { "else", TokenType.ELSE },
            { "return", TokenType.RETURN },
            { "true", TokenType.TRUE },
            { "false", TokenType.FALSE },
        };

        public Token(TokenType type, string literal)
        {
            this.Type = type;
            this.Literal = literal;
        }

        // if Keywords contain inputted string, return Keyword[identifier].
        // if Keywords don't contain inputted string, return it as IDENTIFIER.
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
        IF,
        ELSE,
        RETURN,
        TRUE,
        FALSE,

        // and more...
    }
}