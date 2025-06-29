using LivingDocumentation.Attributes;

namespace Demo.Domain.UserAggregate;

[Entity("User", "Describe an user")]
public class UserEntity
{
    public string UserName { get; set; }
}