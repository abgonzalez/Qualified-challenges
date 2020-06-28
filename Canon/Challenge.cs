using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// https://www.codeproject.com/Questions/1265026/How-do-I-build-a-mock-comments-section
/// </summary>
namespace Canon
{
    public class Challenge
    {
        public class User
        {
            public string Name { get ; set ; }
            public bool IsModerator { get; set; }
            public bool IsAdmin { get; set; }
            public bool isLoggedIn { get; set; }
            public DateTime lastLoggedInAt { get; set; }

            public User(string name)
            {
                Name = name;
                IsModerator = false;
                IsAdmin = false;
            }
            public bool IsLoggedIn()
            {
                return isLoggedIn;
            }
            public DateTime GetLastLoggedInAt()
            {
                return lastLoggedInAt;
            }
            public void SetLastLoggedInAt()
            {
                lastLoggedInAt=DateTime.Now;
            }
            public void LogIn()
            {
                isLoggedIn = true;
            }
            public void LogOut()
            {
                isLoggedIn = false;
            }

            public void SetName(string name)
            {
                Name = name;
            }

            public string GetName()
            {
                return Name;
            }

            public bool CanEdit(Comment comment)
            {
                if (comment.GetAuthor() == this)
                    return true;
                else if (comment.GetAuthor().IsAdmin)
                    return true;
                return false;
            }
            public bool CanDelete(Comment comment)
            {
                if (comment.GetAuthor() == this)
                    return true;
                else if (comment.GetAuthor().IsAdmin || comment.GetAuthor().IsModerator)
                    return true;
                return false;
            }

           
        }

        public class Moderator : Challenge.User
        {
            public Moderator(string name) : base(name)
            {
                IsModerator = true;
            }
            
        }
        public class Admin : Challenge.User
        {
            public Admin(string name) : base(name)
            {
                IsAdmin = true;
            }
          
        }

        public class Comment 
        {
            public User Author { get; set; }
            public string Message { get; set; }
            public Comment RepliedTo { get; set; }
            public DateTime CreatedAt { get; set; }

            public Comment(User author, string message, Comment repliedTo= null)
            {
                Author = author;
                Message = message;
                RepliedTo = repliedTo;
                CreatedAt = DateTime.Now;
            }

            public string GetMessage()
            {
                return Message;
            }
            public void SetMessage(string message)
            {
                Message = message;
            }
            public User GetAuthor()
            {
                return Author;
            }
            public DateTime GetCreatedAt()
            {
                return CreatedAt;
            }
            public Comment GetRepliedTo()
            {
                return RepliedTo;
            }
            public override string ToString()
            {
                return "[" + GetCreatedAt() + "] [" + GetAuthor().GetName() + "] [" + GetMessage() +
                       GetRepliedTo() != null
                    ? ("] [" + GetRepliedTo() + "]")
                    : "]";
            }
        }
    }
}