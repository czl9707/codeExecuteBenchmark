# A very simple performance benchmark against function call

| Method                          | Mean       | Error     | StdDev    | Median     |
|-------------------------------- |-----------:|----------:|----------:|-----------:|
| FunctionCall_Normal             |  0.0287 ns | 0.0191 ns | 0.0169 ns |  0.0281 ns |
| FunctionCall_Delegate           |  0.5658 ns | 0.0346 ns | 0.0324 ns |  0.5616 ns |
| FunctionCall_Reflection         | 46.9885 ns | 0.9434 ns | 0.9265 ns | 46.8737 ns |
| FunctionCall_Interceptor        |  0.0369 ns | 0.0192 ns | 0.0170 ns |  0.0363 ns |
| FucntionCall_Lambda             |  0.0253 ns | 0.0279 ns | 0.0247 ns |  0.0177 ns |
| FucntionCall_CompiledExpression |  2.2099 ns | 0.0648 ns | 0.0606 ns |  2.1811 ns |