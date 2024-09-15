namespace CommonLib;

using System.Linq.Expressions;

/// <summary>
/// Static class that provides guard clauses.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Ensures the string value of the given <paramref name="argumentExpression" /> is not null or empty.
    /// Throws <see cref="ArgumentNullException" /> in the first case, or
    /// <see cref="ArgumentException" /> in the latter.
    /// </summary>
    /// <param name="argumentExpression">The function to get the value.</param>
    public static void NotNullOrEmpty(Expression<Func<string>> argumentExpression)
    {
        var value =
            GetValue(argumentExpression)
            ?? throw new ArgumentNullException(GetParameterName(argumentExpression), "Parameter must be null");
        if (value.Length == 0)
            throw new ArgumentException("Parameter must be empty", GetParameterName(argumentExpression));
    }

    /// <summary>
    /// Ensures then given <paramref name="argumentExpression" /> is fulfilled.
    /// Throws <see cref="ArgumentException" /> if this is not the case.
    /// </summary>
    /// <param name="argumentExpression">The argument expression.</param>
    /// <param name="message">The exception message.</param>
    /// <exception cref="ArgumentException"></exception>
    public static void Argument(Expression<Func<bool>> argumentExpression, string message)
    {
        var argumentIsTrue = argumentExpression.Compile().Invoke();
        if (!argumentIsTrue)
            throw new ArgumentException(message, GetParameterName(argumentExpression));
    }

    /// <summary>
    /// Ensures the given <paramref name="stateExpression" /> is fulfilled.
    /// Throws <see cref="InvalidOperationException" /> if this is not the case.
    /// </summary>
    /// <param name="stateExpression">The state expression.</param>
    /// <param name="message">The exception message.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void State(Expression<Func<bool>> stateExpression, string message)
    {
        var stateIsTrue = stateExpression.Compile().Invoke();
        if (!stateIsTrue)
            throw new InvalidOperationException(message);
    }

    private static T GetValue<T>(Expression<Func<T>> reference)
        where T : class => reference.Compile().Invoke();

    private static string GetParameterName(Expression expression)
    {
        var lambdaExpression = expression as LambdaExpression;
        var memberExpression = lambdaExpression?.Body as MemberExpression;

        return memberExpression?.Member.Name ?? string.Empty;
    }
}