using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contract;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MushroomController:ControllerBase
{
    private readonly IMushroom _mashroomServices;

    public MushroomController(IMushroom plantService)
    {
        _mashroomServices = plantService;
    }
    
   
    
    
    
    
}