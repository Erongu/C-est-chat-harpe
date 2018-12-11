using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LogController
    {
        private static LogController m_instance = null;

        public static LogController Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new LogController();
                return m_instance;
            }
        }

        public void Network(string message, params object[] objects)
        {
            StackFrame frame = new StackFrame(1);

            Log(ConsoleColor.Magenta, $"[ Network::{frame.GetMethod().DeclaringType.Name} ] {string.Format(message, objects)}");
        }

        public void Debug(string message, params object[] objects)
        {
            StackFrame frame = new StackFrame(1);

            Log(ConsoleColor.Yellow, $"[ DEBUG::{frame.GetMethod().DeclaringType.Name} ] {string.Format(message, objects)}");
        }

        public void Error(string message, params object[] objects)
        {
            StackFrame frame = new StackFrame(1);

            Log(ConsoleColor.Red, $"[ ERROR::{frame.GetMethod().DeclaringType.Name} ] {string.Format(message, objects)}");
        }

        public void Warning(string message, params object[] objects)
        {
            StackFrame frame = new StackFrame(1);

            Log(ConsoleColor.DarkYellow, $"[ WARNING::{frame.GetMethod().DeclaringType.Name} ] {string.Format(message, objects)}");
        }

        public void Info(string message, params object[] objects)
        {
            StackFrame frame = new StackFrame(1);

            Log(ConsoleColor.White, $"[ Info::{frame.GetMethod().DeclaringType.Name} ] {string.Format(message, objects)}");
        }

        private void Log(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
