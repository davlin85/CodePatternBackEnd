using DataStorageAPI.IServices;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static DataStorageAPI.Models.Input.JacketInputModel;

namespace DataStorageAPI.Controllers
{
    /// <summary>
    /// Använder Single Responsibility Principle då controllern har ett ansvar
    /// Uppfyller delvis Liskov substitution principle då modellerna kan bytas ut.
    /// </summary>
    
    [ApiController]
    public class JacketController : GenericController<JacketViewModel, CreateJacketInputModel, UpdateJacketInputModel>
    {
        public JacketController(
            IGenericService<
                JacketViewModel, 
                CreateJacketInputModel, 
                UpdateJacketInputModel> 
            genericService) : base(genericService)
        {
        }
    }
}
 