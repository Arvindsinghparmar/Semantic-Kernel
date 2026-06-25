using Microsoft.SemanticKernel;
using System.ComponentModel;

public class MyPlugin
{
    [KernelFunction, Description("Gets the current date")]
    public string GetDate() => DateTime.Now.ToString("D");

    [KernelFunction, Description("Adds two numbers")]
    public int Add(int a, int b) => a + b;
}

