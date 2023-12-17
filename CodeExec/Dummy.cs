namespace Zain.CodeExecuteBenchmark.CodeExec;

public class MyClass
{
    public int baseInt { get; set; }
    public MyClass(int baseInt)
    {
        this.baseInt = baseInt;
    }

    public int AddThreeTimes(int i)
    {
        return this.baseInt + 3 * i;
    }
}
