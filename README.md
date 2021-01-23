# .net-framework-sample-backend-project


In this project, there are sample coding for some structures that a backend application may need.

## Steps to Setup

1. Clone the application.
2. Open the project in Visual Studio.
3. In Solution Explorer, right click the solution and select **Restore NuGet Packages**.
4. On the menu bar, choose **Build** and then choose **Clean Solution**.
5. On the menu bar, choose **Build** and then choose **Build Solution**.
6. Press the green arrow (**Start Button**) on the main Visual Studio toolbar.

### What can you find in this project?

##### Dependency Injection
- used: [Ninject](http://www.ninject.org/)
- integration: [SetResolver Method](Shop.MVCWebUI/Global.asax.cs#L22)

##### Validation
- used: [FluentValidation](https://fluentvalidation.net/)
- tests: [ProductValidatorTests.cs](Shop.Business.Tests/ValidationTests/FluentValidation/ProductValidatorTests.cs)

##### Logging
- used: [log4net](https://logging.apache.org/log4net/)
- tests: [Log4NetTests.cs](Shop.Core.Tests/CrossCuttingConcerns/Logging/Log4NetTests.cs), [Log4NetAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/Log4NetAspectTests.cs)

##### Caching
- used: [MemoryCache](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.caching.memorycache?view=dotnet-plat-ext-5.0)
- tests: [CacheAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/CacheAspectTests.cs),  [CacheRemoveAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/CacheRemoveAspectTests.cs)

##### Transaction
- used: [Postsharp](https://www.postsharp.net/)
- tests: [TransactionScopeAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/TransactionScopeAspectTests.cs)

##### Role-Based Authorization
- used: [Postsharp](https://www.postsharp.net/), [System.Security.Principal](https://docs.microsoft.com/tr-tr/dotnet/api/system.security.principal?view=dotnet-plat-ext-5.0), [FormsAuthenticationTicket](https://docs.microsoft.com/en-us/dotnet/api/system.web.security.formsauthenticationticket?view=netframework-4.8)
- tests: [AuthorizationAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/AuthorizationAspectTests.cs)
- web integration: [AuthenticationHelper.cs](Shop.Core/CrossCuttingConcerns/Security/Web/AuthenticationHelper.cs), [ OnPostAuthenticateRequest Method](Shop.MVCWebUI/Global.asax.cs#L31)
- login: [Login Action](Shop.MVCWebUI/Controllers/HomeController.cs#L35)

##### Field Level Role-Based Authorization
- used: [Postsharp](https://www.postsharp.net/),  [FluentValidation](https://fluentvalidation.net/)
- tests: [FieldLevelAuthorizationAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/FieldLevelAuthorizationAspectTests.cs)

##### Performance Counter
- used: [Postsharp](https://www.postsharp.net/), [Stopwatch](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-5.0)
- tests: [PerformanceCounterAspectTests.cs](Shop.Business.Tests/AspectTests/Postsharp/PerformanceCounterAspectTests.cs)

##### Generate Fake Data
- used: [Bogus](https://github.com/bchavez/Bogus)
- integration: [ShopContextDbInitializer.cs](Shop.DataAccess/Concrete/EntityFramework/Configuration/DatabaseInitializers/ShopContextDbInitializer.cs)

##### Generic Repository
- integration: [EfEntityRepositoryBase.cs](Shop.Core/DataAccess/EntityFramework/EfEntityRepositoryBase.cs)

### Author

**Furkan Işıtan**

* [github/furkanisitan](https://github.com/furkanisitan)
