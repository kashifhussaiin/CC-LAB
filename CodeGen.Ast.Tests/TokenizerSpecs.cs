﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Superpower;
using Xunit;

namespace CodeGen.Ast.Tests
{
    public class TokenizerSpecs
    {
        [Theory]
        [MemberData(nameof(TokenData))]
        public void TokenizationTest(string code, IEnumerable<LangToken> tokens)
        {
            var sut = CreateSut();
            var actual = sut.Tokenize(code).Select(t => t.Kind);
            var expected = tokens;

            actual.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> TokenData()
        {
            return new List<object[]>()
            {
                new object[] {"true", new List<LangToken>() {LangToken.True},},
                new object[] {"false", new List<LangToken>() {LangToken.False},},
                new object[] {"==", new List<LangToken>() {LangToken.DoubleEqual},},
                new object[] {"14", new List<LangToken>() {LangToken.Number},},
                new object[] {"a14", new List<LangToken>() {LangToken.Identifier},},
                new object[] {"=", new List<LangToken>() {LangToken.Equal},},
                new object[] {"ifSomething", new List<LangToken>() {LangToken.Identifier},},
                new object[]
                {
                    "if whileRunning == true", 
                    new List<LangToken>()
                    {
                        LangToken.If,
                        LangToken.Identifier,
                        LangToken.DoubleEqual,
                        LangToken.True,
                    },
                },
            };
        }

        private static Tokenizer<LangToken> CreateSut()
        {
            return TokenizerFactory.Create();
        }
    }
}