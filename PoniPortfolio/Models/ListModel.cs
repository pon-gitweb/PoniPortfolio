namespace PoniPortfolio.Models
{
    public class ListModel
    {
        public IList<Media> MediaModel { get; set; }
        public IList<Experience> ExperienceModel { get; set; }
        public IList<Skills> SkillsModel { get; set; }
        public IList<Qualifications> QualificationsModel { get; set; }
    }
}
