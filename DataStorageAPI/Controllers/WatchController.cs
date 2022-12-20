using DataStorageAPI.IServices;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static DataStorageAPI.Models.Input.WatchInputModel;

namespace DataStorageAPI.Controllers
{
    /// <summary>
    /// Använder Single Responsibility Principle då controllern har ett ansvar
    /// Uppfyller delvis Liskov substitution principle då modellerna kan bytas ut.
    /// </summary>
    
    [ApiController]
    public class WatchController : GenericController<WatchViewModel, CreateWatchInputModel, UpdateWatchInputModel>
    {
        public WatchController(
            IGenericService<
                WatchViewModel,
                CreateWatchInputModel,
                UpdateWatchInputModel>
            genericService) : base(genericService)
        {
        }
    }
}
