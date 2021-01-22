using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class SplashScreenException : ApplicationException
    {
        public string exMessage { get; }
        public DateTime exTime { get; }
        public SplashScreenException() { }
        public SplashScreenException(string message, DateTime time)
        {
            exMessage = message;
            exTime = time;
        }

        public override string Message => String.Format($"Message fo player: Be carefull and don`t do anything stupid!\n{exMessage}");
    }
}
