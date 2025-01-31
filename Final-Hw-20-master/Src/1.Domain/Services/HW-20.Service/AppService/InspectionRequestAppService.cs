using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Service.AppService
{
    public class InspectionRequestAppService : IInspectionRequestAppService
    {
        private readonly IInspectionRequestService _InspectionRequestService;

        public InspectionRequestAppService(IInspectionRequestService InspectionRequestService)
        {
            _InspectionRequestService = InspectionRequestService;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            var result = _InspectionRequestService.AddInspectionRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate);
            return result;
        }

        public bool AddOldCarRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            var result = _InspectionRequestService.AddOldCarRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate);
            return result;
        }

        public List<InspectionRequest> Get(RequestStatusEnum status)
        {
            return _InspectionRequestService.Get(status);
        }


    }
}

