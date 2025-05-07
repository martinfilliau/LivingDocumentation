using LivingDocumentation.Attributes;

namespace Demo;

public class TestClass
{
    [RefactorNeeded("Should be able to return something else", RefactorNeededReason.Testability)]
    public int TestMethod() => 1;
}
