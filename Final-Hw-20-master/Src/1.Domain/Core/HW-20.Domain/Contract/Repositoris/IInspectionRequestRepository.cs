using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface IInspectionRequestRepository
    {

        bool AddInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate);
        bool AddOldCarRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate);
        List<InspectionRequest> Get(RequestStatusEnum status);
        InspectionRequest GetInspectionRequest(int id, RequestStatusEnum status);
    }
}
