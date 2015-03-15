﻿using System;

namespace DNSAgent
{
    internal class Logger
    {
        private static readonly object OutputLock = new object();
        private static string _title;

        public static string Title
        {
            get { return Environment.UserInteractive ? Console.Title : _title; }
            set
            {
                if (Environment.UserInteractive)
                    Console.Title = value;
                else
                    _title = value;
            }
        }

        public static void Error(string format, params object[] arg)
        {
            WriteLine(ConsoleColor.Red, format, arg);
        }

        public static void Warning(string format, params object[] arg)
        {
            WriteLine(ConsoleColor.Yellow, format, arg);
        }

        public static void Info(string format, params object[] arg)
        {
            WriteLine(ConsoleColor.Gray, format, arg);
        }

        public static void Debug(string format, params object[] arg)
        {
            WriteLine(ConsoleColor.Magenta, format, arg);
        }

        public static void Trace(string format, params object[] arg)
        {
            WriteLine(ConsoleColor.White, format, arg);
        }

        private static void WriteLine(ConsoleColor textColor, string format, params object[] arg)
        {
            lock (OutputLock)
            {
                Console.ForegroundColor = textColor;
                Console.WriteLine(format, arg);
                Console.ResetColor();
            }
        }
    }
}