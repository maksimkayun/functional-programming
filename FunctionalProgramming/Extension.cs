namespace FunctionalProgramming;

public class Extension : IComparer<int>
{
    public int Compare(int x, int y) {
        if (x % 2 == y % 2) {
            // all is odd or is even
            return x.CompareTo(y);
        }
        // One is odd, the other one is even
        if (x % 2 == 0) {
            return -1;
        }
        return 1;
    }
}