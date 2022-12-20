using DataStorageAPI.IServices;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static DataStorageAPI.Models.Input.ShoesInputModel;

namespace DataStorageAPI.Controllers
{
    /// <summary>
    /// Använder Single Responsibility Principle då controllern har ett ansvar
    /// Uppfyller delvis Liskov substitution principle då modellerna kan bytas ut.
    /// </summary>
    
    [ApiController]
    public class ShoesController : GenericController<ShoesViewModel, CreateShoesInputModel, UpdateShoesInputModel>
    {
        public ShoesController(
            IGenericService<
                ShoesViewModel, 
                CreateShoesInputModel, 
                UpdateShoesInputModel> 
            genericService) : base(genericService)
        {
        }
    }
}
