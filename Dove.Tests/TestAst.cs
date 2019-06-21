using Dove.Ast;
using Dove.Ast.Expressions;
using Dove.Ast.Statements;
using Dove.Lexing;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    public class AstTest
    {
        [Fact]
        public void TestNodeToCode1()
        {
            var code = "let x = abc;";

            var root = new Root();
            root.Statements = new List<IStatement>();

            root.Statements.Add(
                new LetStatement()
                {
                    Token = new Token(TokenType.LET, "let"),
                    Name = new Identifier(
                        new Token(TokenType.IDENT, "x"),
                        "x"
                    ),
                    Value = new Identifier(
                        new Token(TokenType.IDENT, "abc"),
                        "abc"
                    ),
                } 
            );

            Assert.Equal(code, root.ToCode());
        }
    }
}