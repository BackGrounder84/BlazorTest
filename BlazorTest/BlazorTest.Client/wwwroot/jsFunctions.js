const assemblyName = 'BlazorTest.Client';
const namespace = 'BlazorTest.Client.Utils';
const typeName = 'StringUtil';
const methodName = 'Combine';

Blazor.registerFunction('say', (data) => {
    alert('Hallo together');
    return true;
});

Blazor.registerFunction('combine', (data) => {
    const combineMethod = Blazor.platform.findMethod(
        assemblyName,
        namespace,
        typeName,
        methodName
    );

    let arg1AsDotNetString = Blazor.platform.toDotNetString(data.firstString);
    let arg2AsDotNetString = Blazor.platform.toDotNetString(data.secondString);

    let resultAsDotNetString = Blazor.platform.callMethod(combineMethod, null, [
        arg1AsDotNetString,
        arg2AsDotNetString
    ]);
    
    return Blazor.platform.toJavaScriptString(resultAsDotNetString);
});