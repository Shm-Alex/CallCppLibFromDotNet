# Test Task for Software Developers
## Objective
*Modernize a small .NET Framework application to dotnet 9, ensuring compatibility with C++ interop, manual loading of the C++ library, and
containerization. Optionally, expose the simple operation via a Web API.*
## Requirements
1. Create a simple .NET Framework application using C# that includes:
    1. A basic UI with a button and a text box,
    1. A C++ class library that performs a simple operation (e.g., string manipulation or mathematical calculation),
    1. Implement C++ interop to call the C++ class library from the C# application;
1. Migrate the .NET Framework application to dotnet 9, following best practices for modernization:
    1. Update the project file format (e.g., from .csproj to .NET SDK-style projects),
    1. Replace any deprecated APIs with their newer equivalents,
    1. Ensure the application uses the latest C# language features where appropriate;
1. Manually load the C++ library instead of using DllImport:
    1. Use the manual loading to load the C++ library (do not use DllImport);
    1. Expose the simple operation via a Web API:
    1. Create a dotnet 9 Web API project and reference the modernized application,
1. Implement a controller with a route that calls the simple operation from the C++ library,
    1. Ensure the Web API can be accessed and executed correctly;
1. Containerize the application using Docker:
    1.  Create a Dockerfile to define the container image,
    1. Choose an appropriate base image for the dotnet 9 application (Debian 12 is strongly recommended),
    1. Configure the container to run the application correctly.
   
- *Ensure the application still functions correctly after modernization, that the C++ interop continues to work as expected, and that the containerized application runs successfully.*
- *Provide a brief documentation on the steps you took during the modernization process, including any challenges faced and the solutions you implemented to overcome them.*
   
## Deliverables
1. The original .NET Framework application source code;
1. C++ library source code;
1. The updated dotnet 9 application source code with C++ interop;
1. The Dockerfile and any necessary configuration files for containerization;
1. Documentation detailing the modernization process.

*Candidates are expected to cover the source code by unit tests, regression tests, e2e tests, load tests, and fuzzing tests. It is prohibited to use Visual Studio based project and solution configurations.*

## Videos about code 
- https://youtu.be/3M8xenTGnmw вступление
- https://youtu.be/JEXterqe-h8 первое упражнение Cpp проект(CppSourceCodeProject)   Дот нет проект(CallCppFromNet) с вызовом Cpp кода из приложения
- https://youtu.be/KNUvZW4u4Vw второе упражнение Net Core  проект (CrossPlatformConsole) с вызовом Cpp кода из приложения
- https://youtu.be/uNCh4hc5tbw третье упражнение Net Standard проект(DotNetStandardCppWrapper) с обёрткой над вызовами сторонней  библиотеки Часть I
- https://youtu.be/BQbvXpOwvuM третье упражнение Net Standard проект(DotNetStandardCppWrapper) с обёрткой над вызовами сторонней  библиотеки Часть II
- https://youtu.be/icjJv2YyRK4 четвёртое  упражнение Web APi  проект (WebApiProxy2Cpp) Инъекция имплементации вызова сервиса, валидация параметоров, подключение Swagger
- https://youtu.be/7WPWcBI786s пятое   упражнение  контейнеризация Web APi
