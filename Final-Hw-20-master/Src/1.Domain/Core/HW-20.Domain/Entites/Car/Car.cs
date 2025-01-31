namespace HW_20.Domain.Entites.Car
{
    public class Car
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region NavigationProperties
        public int CardModelId { get; set; }
        public List<CarModel> CarModels { get; set; }
        public int ManufacturerId { get; set; } 
        public CarManufacturer Manufacturer { get; set; }
        #endregion
    }
}
