using System.ComponentModel;


namespace JuniorMath.ApplicationCore.Enums
{
    public enum SiteUserLevelType
    {
        [Description("AdminUser")]
        AdminUser = 1,
        [Description("Teacher")]
        Teacher = 2,
        [Description("Student")]
        Student = 3
    }


    public enum QuestionType
    {
        [Description("Image Count")]
        ImageCount = 1
    }
}
