using JuniorMath.ApplicationCore.Entities.SettingsAggregate;


namespace JuniorMath.ApplicationCore.Entities.DoctorAggregate
{
    public partial class DoctorSpecality : BaseEntity
    {
        public int DoctorId { get; set; }
        public int SpecalityId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Specality Specality { get; set; }
    }
}
