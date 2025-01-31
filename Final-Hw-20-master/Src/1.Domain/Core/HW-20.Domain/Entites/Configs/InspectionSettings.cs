namespace HW_20.Domain.Entites.Configs
{
    public class InspectionSettings
    {
        //ظرفیت روزهای فرد و زوج برای تعداد درخواست‌ها 
        #region Properties
        public int MaxOddDayRequests { get; set; }
        public int MaxEvenDayRequests { get; set; }
        public int ProductionYear { get; set; }
        #endregion
    }

}
