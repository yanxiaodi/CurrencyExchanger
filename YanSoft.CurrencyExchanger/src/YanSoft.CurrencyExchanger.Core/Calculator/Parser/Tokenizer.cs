/***********************************************************
 *
 *   Copyright (c) Microsoft Corporation, 2004
 *
 *   Description:   The Tokenizer converts a string representing
 *                  a mathematical function into symbolic tokens
 *                  used by the parser to create an expression tree.
 *   Created:       8/19/04
 *   Author:        Bob Brown (robbrow)
 *   
 *   Modified on:   3/21/2010
 *   by:            Kambiz Nazridoust
 *
 ************************************************************/

using System;
using System.Globalization;

namespace YanSoft.CurrencyExchanger.Core.Calculator.Parser
{
    public enum TokenType
    {
        None = 0x0,
        Constant = 0x1,
        Variable = 0x2,
        Plus = 0x4,
        Minus = 0x8,
        Multiply = 0x10,
        Divide = 0x20,
        Exponent = 0x40,
        Sine = 0x80,
        Cosine = 0x100,
        Tangent = 0x200,
        SineHyper = 0x90,
        CosineHyper = 0x110,
        TangentHyper = 0x210,
        Log = 0x300,
        Log10 = 0x500,
        Sgn = 0x600,
        Sqrt = 0x700,
        Abs = 0x750,
        Factorial = 0x900,
        OpenParen = 0x400,
        CloseParen = 0x800,
        EOF = 0x1000,
    }
    public class TokenSet
    {
        public TokenSet(TokenType type)
        {
            this.tokens = (uint)type;
        }

        public TokenSet(TokenSet t)
        {
            this.tokens = t.tokens;
        }

        private TokenSet(uint tokens)
        {
            this.tokens = tokens;
        }

        public static TokenSet operator +(TokenSet t1, TokenSet t2)
        {
            return new TokenSet((uint)t1.tokens | (uint)t2.tokens);
        }

        public static TokenSet operator +(TokenSet t1, TokenType t2)
        {
            return new TokenSet(t1.tokens | (uint)t2);
        }

        public bool Contains(TokenType type)
        {
            return (tokens & (uint)type) != 0;
        }

        private uint tokens;
    }
    public struct Token
    {
        public Token(string value, TokenType type)
        {
            this.value = value;
            this.type = type;
        }

        public readonly string value;
        public readonly TokenType type;
    }
    public class Tokenizer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        public Tokenizer(string function)
        {
            if (function == null)
            {
                function = string.Empty;
            }
            this.function = function;
            this.index = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Token Next()
        {
            while (index < function.Length)
            {
                if (IsNumber(function[index]))
                {
                    string val = string.Empty;
                    val += function[index++];
                    while (index < function.Length && IsNumber(function[index]))
                    {
                        val += function[index++];
                    }
                    return new Token(val, TokenType.Constant);
                }

                if (IsAlpha(function[index]))
                {
                    string var = string.Empty;
                    var += function[index++];

                    while (index < function.Length && IsAlpha(function[index]))
                        var += function[index++];

                    switch (var.ToLower())
                    {
                        case "sin":
                            return new Token("sin", TokenType.Sine);
                        case "cos":
                            return new Token("cos", TokenType.Cosine);
                        case "tan":
                            return new Token("tan", TokenType.Tangent);
                        case "sinh":
                            return new Token("sinh", TokenType.SineHyper);
                        case "cosh":
                            return new Token("cosh", TokenType.CosineHyper);
                        case "tanh":
                            return new Token("tanh", TokenType.TangentHyper);
                        case "log":
                            return new Token("log", TokenType.Log10);
                        case "ln":
                            return new Token("log10", TokenType.Log);
                        case "sgn":
                            return new Token("sqn", TokenType.Sgn);
                        case "sqrt":
                            return new Token("sqrt", TokenType.Sqrt);
                        case "abs":
                            return new Token("abs", TokenType.Abs);
                        default:
                            return new Token(var, TokenType.Variable);
                    }
                }

                switch (function[index++])
                {
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                        continue;

                    case '+':
                        return new Token("+", TokenType.Plus);
                    case '-':
                        return new Token("-", TokenType.Minus);
                    case '*':
                        return new Token("*", TokenType.Multiply);
                    case '/':
                        return new Token("/", TokenType.Divide);
                    case '^':
                        return new Token("^", TokenType.Exponent);
                    case '!':
                        return new Token("!", TokenType.Factorial);
                    case '(':
                        return new Token("(", TokenType.OpenParen);
                    case ')':
                        return new Token(")", TokenType.CloseParen);
                    default:
                        throw new InvalidSyntaxException("Invalid token '" + function[index - 1] + "' in function: " + function);
                }
            }
            return new Token("", TokenType.EOF);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsAlpha(char c)
        {
            return (('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z'));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsNumber(char c)
        {
            return ('.' == c || ('0' <= c && c <= '9'));
        }

        private string function;
        private int index;
    }
}
