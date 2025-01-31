namespace HW_20.Domain.Entites.Car
{
    public class CarManufacturer
    {
        #region Properties
        // تولیدکننده خودرو
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region NavigationProperties
        public int CardId { get; set; }
        public List<Car> Cars { get; set; }
        #endregion
    }
}
