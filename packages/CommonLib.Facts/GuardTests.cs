namespace CommonLib.Facts;

using FluentAssertions;

public class GuardTests
{
    [Fact]
    public void DoesNotThrowOnValidStringArgument()
    {
        const string Argument = "Argument";

        var guard = () => Guard.NotNullOrEmpty(() => Argument!);
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsNullStringArgument()
    {
        const string? Argument = default;

        var guard = () => Guard.NotNullOrEmpty(() => Argument!);
        guard.Should().Throw<ArgumentException>().WithMessage("Parameter must be null");
    }

    [Fact]
    public void DetectsEmptyStringArgument()
    {
        const string Argument = "";

        var guard = () => Guard.NotNullOrEmpty(() => Argument!);
        guard.Should().Throw<ArgumentException>().WithMessage("Parameter must be empty");
    }

    [Fact]
    public void DoesNotThrowOnValidArgument()
    {
        const int Argument = 4;

        var guard = () => Guard.Argument(() => Argument < 5, "Argument must be smaller than 5");
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsInvalidArgument()
    {
        const int Argument = 5;

        var guard = () => Guard.Argument(() => Argument < 5, "Argument must be smaller than 5");
        guard.Should().Throw<ArgumentException>().WithMessage("Argument must be smaller than 5");
    }

    [Fact]
    public void DoesNotThrowOnValidState()
    {
        const int State = 4;

        var guard = () => Guard.State(() => State < 5, "State must be smaller than 5");
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsInvalidState()
    {
        const int State = 5;

        var guard = () => Guard.Argument(() => State < 5, "State must be smaller than 5");
        guard.Should().Throw<ArgumentException>().WithMessage("State must be smaller than 5");
    }
}