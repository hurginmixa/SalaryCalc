using System;
using System.Text;

namespace SalaryCalc
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
            Console.SetCursorPosition(left: left, top: top);
            Console.Write(PrepareText(text, length));
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

            eInputResult InputResult(out ConsoleKeyInfo keyInfo)
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


            while ((inputResult = InputResult(out var keyInfo)) == eInputResult.None)
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

            return txt.ToString();
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