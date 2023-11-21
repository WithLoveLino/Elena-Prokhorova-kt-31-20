namespace ProkhorovaKT_31_20.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
