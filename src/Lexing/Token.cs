namespace Dove.Lexing
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }

        public Token(TokenType type, string literal)
        {
            this.Type = type;
            this.Literal = literal;
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