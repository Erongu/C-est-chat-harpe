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
        public const bool DEBUG = true;

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
            if (!DEBUG)
                return;

            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();

            Log(ConsoleColor.Yellow, $"[ DEBUG::{method.DeclaringType.Name}::{method.Name} ] {string.Format(message, objects)}");
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
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
