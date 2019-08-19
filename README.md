## Usage: ASP&#46;NET Core Web Application
### appsettings.json
```JSON
{
  "badwords": "http://example.com/badwords.txt",
```

### Startup.cs
```C#
public void ConfigureServices(IServiceCollection services)
{
    ...

    var profanityRepository = new ProfanityRepository();
    var uriString = Configuration.GetValue<string>("badwords");
    var badwords = profanityRepository.ReadAsync(new Uri(uriString)).Result;
    services.AddSingleton<IProfanityService>(sp => new ProfanityService(badwords));
}
```

### HomeController.cs
```C#
public class HomeController : Controller
{
    private readonly IProfanityService _profanityService;

    public HomeController(IProfanityService profanityService)
    {
        _profanityService = profanityService;
    }

    [HttpPost]
    public IActionResult Contact(ContactViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (_profanityService.HasBadWords(viewModel.Message))
            {
                ModelState.AddModelError("Message", "Message contains inappropriate words");
            }
        }

        return View();
    }
```

## Usage: ASP&#46;NET Web Application (&#46;NET Framework)
### Web.config
```XML
<configuration>
  <appSettings>
    <add key="badwords" value="http://example.com/badwords.txt"/>
```

### Global.asax.cs
```C#
public class MvcApplication : System.Web.HttpApplication
{
    public static IProfanityService ProfanityService { get; set; }

    protected void Application_Start()
    {
        ...

        var profanityRepository = new ProfanityRepository();
        var uriString = ConfigurationManager.AppSettings["badwords"];
        var badwords = profanityRepository.ReadAsync(new Uri(uriString)).Result;
        ProfanityService = new ProfanityService(badwords);
    }
}
```

### HomeController.cs
```C#
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Contact([Bind(Include = "Name,Email,Subject,Message")] ContactViewModel viewModel)
{
    if (ModelState.IsValid)
    {
        if (MvcApplication.ProfanityService.HasBadWords(viewModel.Message))
        {
            ModelState.AddModelError("Message", "Message contains inappropriate words");
        }
```