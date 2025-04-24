using CommonTestUtilities.Request.Activities;

namespace Validator.Test.Activities;
public class RegisterActivityValidatorTest
{

    [Fact]
    public void Sucess()
    {
        var request = RequestRegisterActityJsonBuilder.Build();
    }
}
