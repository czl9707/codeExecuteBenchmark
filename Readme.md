# A very simple performance benchmark against function call

| Method                   | Mean       | Error     | StdDev    |
|------------------------- |-----------:|----------:|----------:|
| FunctionCall_Normal      |  0.0187 ns | 0.0060 ns | 0.0056 ns |
| FunctionCall_Delegate    |  0.0403 ns | 0.0047 ns | 0.0044 ns |
| FunctionCall_Reflection  | 20.7470 ns | 0.0719 ns | 0.0600 ns |
| FunctionCall_Interceptor |  0.0192 ns | 0.0059 ns | 0.0055 ns |