using NSubstitute; // To use Substitute.
using Bogus; // To use Faker<T>.
using Packt.Shared; // To use User, UserService.
using Xunit.Abstractions; // To use ITestOutputHelper.

namespace BogusTests;

public class BogusExamples
{
  private readonly ITestOutputHelper _output;
  private readonly Faker<User> _userFaker;

  public BogusExamples(ITestOutputHelper output)
  {
    _output = output;

    _userFaker = new Faker<User>()
      // Configure an incrementing index for the Id property.
      .RuleFor(u => u.Id, f => f.IndexFaker + 1)
      // Configure the FirstName property to be a random first name.
      .RuleFor(u => u.FirstName, f => f.Name.FirstName())
      // Configure the LastName property to be a random last name.
      .RuleFor(u => u.LastName, f => f.Name.LastName())
      // Configure the Email property to be a random email address.
      .RuleFor(u => u.Email, f => f.Internet.Email())
      // Configure the DateOfBirth property to be a random date of birth
      // up to 30 years earlier than 18 years ago.
      .RuleFor(u => u.DateOfBirth, f => f.Date.Past(yearsToGoBack: 30,
        refDate: DateTime.Now.AddYears(-18)));
  }

  [Fact]
  public void IsAdult_ShouldReturnTrue_WhenUserIs18OrOlder()
  {
    // Arrange
    IEmailSender emailSender = Substitute.For<IEmailSender>();
    UserService userService = new(emailSender);
    User user = _userFaker.Generate();
    _output.WriteLine($"{user}");
    // Act
    bool result = userService.IsAdult(user);
    // Assert
    Assert.True(result);
  }

  [Fact]
  public void IsAdult_ShouldReturnFalse_WhenUserIsUnder18()
  {
    // Arrange
    IEmailSender emailSender = Substitute.For<IEmailSender>();
    UserService userService = new(emailSender);
    User user = _userFaker.Clone()
      // Override the DateOfBirth property to be a random date of birth
      // up to 10 years earlier than 8 years ago i.e. under 18.
      .RuleFor(u => u.DateOfBirth, f => f.Date.Past(yearsToGoBack: 10,
        refDate: DateTime.Now.AddYears(-8)))
      .Generate();
    _output.WriteLine($"{user}");

    // Act
    bool result = userService.IsAdult(user);
    // Assert
    Assert.False(result);
  }
}
