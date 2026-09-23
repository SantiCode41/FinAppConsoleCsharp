using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppCsharp
{
    internal class User
    {
        public long userId = -1;
        public string username;
        public string firstName;
        public string lastName;
        public string password;

        public User()
        {
        }

        public User(string username, string firstName, string lastName, string password)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
        }

        public void Copy(User userToCopy)
        {
            this.userId = userToCopy.userId;
            this.username = userToCopy.username;
            this.firstName = userToCopy.firstName;
            this.lastName = userToCopy.lastName;
            this.password = userToCopy.password;
        }
    }
}
