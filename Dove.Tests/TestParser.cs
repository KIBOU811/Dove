using Dove.Lexing;
using Dove.Parsing;
using Dove.Ast.Statements;
using Dove.Ast;
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

            Assert.Equal(
                root.Statements.Count, 3
            );

            var tests = new string[] { "x", "y", "xyz" };
            for (int i = 0; i < tests.Length; i++)
            {
                var name = tests[i];
                var statement = root.Statements[i];
                this._TestLetStatement(statement, name);
            }
        }

        private void _TestLetStatement(IStatement statement, string name)
        {
            Assert.Equal(
                statement.TokenLiteral(), "let"
            );

            var letStatement = statement as LetStatement;
            if (letStatement == null)
            {
                _output.WriteLine("statement が LetStatement ではありません。");
            }

            Assert.Equal(
                letStatement.Name.Value, name
            );

            Assert.Equal(
                letStatement.Name.TokenLiteral(), name
            );

        }
    }
}