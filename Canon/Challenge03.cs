using System;
public class Challenge
{
  public class User 
  {
    private readonly string _name;
    private readonly bool _loggedIn;
    private readonly DateTime _lastLoggedInAt;
    
    public User(string name) {
       this._name=name;
    }
    
    public bool IsLoggedIn() {
      return _loggedIn;
    }
    
    public DateTime GetLastLoggedInAt() {
      return _lastLoggedInAt;
    }
    
    public void LogIn() {
      _loggedIn=true;
      _lastLoggedInAt=DateTime.Now();
    }
    public void LogOut() {
      _loggedIn=false;
    }
    
    public string GetName() {
      return _name;
    }
    public void SetName(string name) {
      _name=name;
    }   
    
    public bool CanEdit(Comment comment) {
      
    }
    public bool CanDelete(Comment comment) {
      
    }
  }

  public class Moderator : User{
    private User user;
    private readonly bool _bEditAdmin;
    private readonly bool _bDeleteAdmin;
    
    public Moderator(String name) {
       this.user= new User(name);
      _bEditAdmin=true;
      _bDeleteAdmin=true;
    }
  }

  public class Admin : User {
    private User user;
    private readonly bool _bEditAdmin;
    private readonly bool _bDeleteAdmin;
    public Admin(String name) {
       this.user= new User(name);
      _bEditAdmin=true;
      _bDeleteAdmin=true;
    }
  }
  
  public class Comment {
    private readonly string _message;
    private readonly DateTime _createdAt;
    private readonly string _author;
    private readonly string _repliedTo;
    
    public Comment(User author, string message, Comment repliedTo) {

         return DateTime.Now + "User " + author.GetName() + ".Message : " + message + "Replied To:" + repliedTo ;


        
    }
    
    public string GetMessage() {
      return _message;
    }
    
    public void SetMessage(String message){
      _message=message;
    }
    
    public DateTime GetCreatedAt() {
       return _createdAt;
    }
   
    
    public User GetAuthor() {
      return _author;
    }

    public Comment GetRepliedTo() {
      return _repliedTo;
    }
    
    public override string ToString() {
      return this.ToString();
    }
  }
}