// BracketChecker: a stack remembers every bracket that is still open,
// and the most recent one is always on top.
//
// Part C. IsBalanced is Exercise 3.
public static class BracketChecker
{
    // True when every (, [, and { is closed by its partner, in order.
    // Brackets go wrong in exactly three ways. Catch all three:
    //   1. closing something that was never opened      ( ) )
    //   2. closing in the wrong order                    ( [ ) ]
    //   3. leaving something open at the end             ( ( )
    // Every other character is ignored.
    public static bool IsBalanced(string text)
    {
        MyStack<char> openings = new MyStack<char>();

        foreach (char character in text)
        {
            if (character == '(' || character == '[' || character == '{')
            {
                openings.Push(character);
            }
            else if (character == ')' || character == ']' || character == '}')
            {
                if (openings.IsEmpty || !Matches(openings.Peek(), character))
                {
                    return false;
                }

                openings.Pop();
            }
        }

        return openings.IsEmpty;
    }

    // Given. True when close is the partner of open.
    public static bool Matches(char open, char close)
    {
        return (open == '(' && close == ')')
            || (open == '[' && close == ']')
            || (open == '{' && close == '}');
    }
}
