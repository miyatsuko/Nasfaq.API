using System;

namespace Nasfaq.JSON
{
    public class LoggedOutException : Exception
    {
        public LoggedOutException()
            :base("Session is logged out of Nasfaq")
        {
        }

        public LoggedOutException(Exception inner)
            :base("Session is logged out of Nasfaq", inner)
        {
        }
    }
}