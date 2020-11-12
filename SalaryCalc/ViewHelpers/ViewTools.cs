using System;
using System.Text;

namespace SalaryCalc.ViewHelpers
{
    internal static class ViewTools
    {
        public enum eInputResult
        {
            None,
            Ok,
            Tab,
            ShiftTab,
            Esc
        }

        public static void Txt(int left, int top, string text)
        {
            Console.SetCursorPosition(left: left, top: top);
            Console.Write(text);
        }

        public static void Txt(int left, int top, int length, string text)
        {
            Txt(left:left, top: top, text: PrepareText(text, length));
        }

        public static string Input(int left, int top, int length, string prev, ConsoleColor color, out eInputResult inputResult)
        {
            Console.ForegroundColor = color;

            prev = PrepareText(prev, length);
            StringBuilder txt = new StringBuilder(prev);

            void RefreshText()
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(left: left, top: top);
                Console.Write(txt.ToString());
            }

            RefreshText();

            int pos = 0;
            Console.CursorVisible = true;
            Console.SetCursorPosition(left: left, top: top);

            while ((inputResult = ReadKey(out var keyInfo)) == eInputResult.None)
            {
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (pos <= 0)
                    {
                        continue;
                    }

                    pos -= 1;
                }
                
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (pos >= length - 1)
                    {
                        continue;
                    }

                    pos += 1;
                }
                
                else if (keyInfo.Key == ConsoleKey.Home)
                {
                    pos = 0;
                }
                
                else if (keyInfo.Key == ConsoleKey.End)
                {
                    pos = Math.Min(txt.ToString().TrimEnd().Length, length - 1);
                }

                else if (pos < length)
                {
                    if (keyInfo.Key == ConsoleKey.Delete)
                    {
                        txt.Remove(pos, 1).Append(' ');
                        RefreshText();
                    }

                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (pos <= 0)
                        {
                            continue;
                        }

                        pos -= 1;
                        txt.Remove(pos, 1).Append(' ');
                        RefreshText();
                    }

                    else if (char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsPunctuation(keyInfo.KeyChar) || keyInfo.KeyChar == ' ')
                    {
                        txt[pos] = keyInfo.KeyChar;
                        pos += 1;
                        if (pos == length)
                        {
                            pos = length - 1;
                        }

                        RefreshText();
                    }
                }

                Console.CursorVisible = true;
                Console.SetCursorPosition(left: left + pos, top: top);
            }

            Console.ResetColor();
            RefreshText();

            return txt.ToString().Trim();
        }

        public static eInputResult WaitToOk(int left, int top, ConsoleColor color, string text)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(left: left, top: top);
            Console.Write(text);

            try
            {
                eInputResult inputResult;
                while ((inputResult = ReadKey(out _)) == eInputResult.None)
                {
                }
                return inputResult;
            }
            finally
            {
                Console.ResetColor();
                Console.SetCursorPosition(left: left, top: top);
                Console.Write(text);
            }
        }

        public static eInputResult WaitToOk(int left, int top, int length, ConsoleColor color, string text)
        {
            return WaitToOk(left: left, top: top, color: color, text: PrepareText(text, length));
        }

        private static eInputResult ReadKey(out ConsoleKeyInfo keyInfo)
        {
            keyInfo = Console.ReadKey(intercept: true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    return eInputResult.Ok;

                case ConsoleKey.Escape:
                    return eInputResult.Esc;

                case ConsoleKey.Tab:
                    return keyInfo.Modifiers != ConsoleModifiers.Shift ? eInputResult.Tab : eInputResult.ShiftTab;

                default:
                    return eInputResult.None;
            }
        }

        private static string PrepareText(string text, int length)
        {
            text = text.Trim();
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }

            text = text.PadRight(length);
            return text;
        }
    }
}