using DataStorageAPI.IServices;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static DataStorageAPI.Models.Input.JeansInputModel;

namespace DataStorageAPI.Controllers
{
    /// <summary>
    /// Använder Single Responsibility Principle då controllern har ett ansvar
    /// Uppfyller delvis Liskov substitution principle då modellerna kan bytas ut.
    /// </summary>
    
    [ApiController]
    public class JeansController : GenericController<JeansViewModel, CreateJeansInputModel, UpdateJeansInputModel>
    {
        public JeansController(
            IGenericService<
                JeansViewModel, 
                CreateJeansInputModel, 
                UpdateJeansInputModel> 
            genericService) : base(genericService)
        {
        }
    }
}
