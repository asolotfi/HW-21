using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Domain.Contract.Sevice
{
    public interface IInspectionRequestService
    {
        bool AddInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate);
        bool AddOldCarRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate);
        List<InspectionRequest> Get(RequestStatusEnum status);
    }
}
