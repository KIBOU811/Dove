using Dove.Lexing;
using Dove.Parsing;
using Dove.Ast.Statements;
using Dove.Ast;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Dove.Tests
{
    public class ParserTest
    {
        private readonly ITestOutputHelper _output;

        public ParserTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestLetStatement1()
        {
            var input = @"let x = 5;
let y = 10;
let xyz = 838383;";

            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseProgram();
            this.CheckParserErrors(parser);

            Assert.Equal(
                root.Statements.Count, 3
            );

            var tests = new string[] { "x", "y", "xyz" };
            for (int i = 0; i < tests.Length; i++)
            {
                var name = tests[i];
                var statement = root.Statements[i];
                this.TestLetStatement(statement, name);
            }
        }

        [Fact]
        public void TestReturnStatement1()
        {
            var input = @"return 5;
return 10;
return = 993322;";

            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseProgram();
            this._CheckParserErrors(parser);

            Assert.Equal(
                root.Statements.Count, 3
            );

            foreach (var statement in root.Statements)
            {
                var returnStatement = statement as ReturnStatement;
                if (returnStatement == null)
                {
                    _output.WriteLine("Statement does not match ReturnStatement.");
                }

                Assert.Equal(
                    returnStatement.TokenLiteral(), "return"
                );
            }
        }

        private void TestLetStatement(IStatement statement, string name)
        {
            Assert.Equal(
                statement.TokenLiteral(), "let"
            );

            var letStatement = statement as LetStatement;
            if (letStatement == null)
            {
                _output.WriteLine("Statement does not match LetStatement.");
            }

            Assert.Equal(
                letStatement.Name.Value, name
            );

            Assert.Equal(
                letStatement.Name.TokenLiteral(), name
            );
        }

        private void CheckParserErrors(Parser parser)
        {
            if (parser.Errors.Count == 0)
                return;
            
            _output.WriteLine("");
            foreach (var e in parser.Errors)
            {
                _output.WriteLine(e);
            }
        }
    }
}