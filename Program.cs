using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Zain.CodeExecuteBenchmark.CodeExec;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace Zain.CodeExecuteBenchmark;

public class FunctionCallBenchmark
{
    private MyClass myClass;
    private MethodInfo myClassMethodInfo;
    private object?[] myClassMethodInvokeParams;
    private Func<int, int> myClassMethodDelegate;
    private Func<int, int> lambdaFunction;
    private Func<int, int> compiledExpressionTree;

    public FunctionCallBenchmark()
    {
        this.myClass = new MyClass(1);
        this.myClassMethodInfo = typeof(MyClass).GetMethod(nameof(MyClass.AddThreeTimes))!;
        this.myClassMethodInvokeParams = new object[] {1};
        this.myClassMethodDelegate = myClass.AddThreeTimes;
        this.lambdaFunction = (int i) => i * 2 + 1;

        var para = Expression.Parameter(typeof(int), "i");
        this.compiledExpressionTree = Expression.Lambda<Func<int, int>>(
            Expression.Add(
                Expression.Multiply(
                    para,
                    Expression.Constant(2)
                ),
                Expression.Constant(1)
            ),
            new List<ParameterExpression> {
                para
            }
        ).Compile();
    }

    [Benchmark]
    public void FunctionCall_Normal()
    {
        this.myClass.AddThreeTimes(1);
    }

    [Benchmark]
    public void FunctionCall_Delegate()
    {
        this.myClassMethodDelegate(1);
    }

    [Benchmark]
    public void FunctionCall_Reflection()
    {
        this.myClassMethodInfo.Invoke(this.myClass, this.myClassMethodInvokeParams);
    }

    [Benchmark]
    public void FunctionCall_Interceptor()
    {
        this.myClass.AddThreeTimes(1);
    }

    [Benchmark]
    public void FucntionCall_Lambda()
    {
        this.lambdaFunction(1);
    }
    
    [Benchmark]
    public void FucntionCall_CompiledExpression()
    {
        this.compiledExpressionTree(1);
    }
}


public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<FunctionCallBenchmark>();
    }
}

public static class InterceptorsHome
{
    [InterceptsLocation("""/home/chen_zeling/for_fun/codeExecuteBenchmark/Program.cs""", line: 63, column: 22)]
    public static int InterceptAddThreeTimes (this MyClass myClass, int i)
    {
        return myClass.baseInt + 2 * i;
    }
}

