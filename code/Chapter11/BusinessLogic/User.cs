namespace Packt.Shared;

public class User
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public DateTime DateOfBirth { get; set; }
  public override string ToString()
  {
    return $"{Id}, {FirstName} {LastName}, {Email}, {DateOfBirth:yyyy-MM-dd}";
  }
}
