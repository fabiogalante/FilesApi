using Microsoft.AspNetCore.Mvc;

namespace FilesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    
    private readonly ILogger<FilesController> _logger;

    public FilesController(ILogger<FilesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {

        string guid;
        string currentDirectory = Directory.GetCurrentDirectory();
        
        _logger.LogInformation($"Current Directory {currentDirectory}");
        string path = "Cripto";
        string fullPath = Path.Combine(currentDirectory, path, "Chave.txt");
        
        _logger.LogInformation($"FullPath {fullPath}");
        using (StreamReader r = new StreamReader(fullPath))
        { 
            guid = r.ReadToEnd();
            
        }
        
        return Ok(guid);
    }
}