using Humanizer;
using System.Data.SqlClient;

namespace Resume_Builder.Models
{
    public class UserDetails
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string Describe { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Git { get; set; }
        public string LinkedIn { get; set; }
        public string WebLink { get; set; }
        public string Picture { get; set; }

        public string AboutText { get; set; }


        public int? ExperienceID { get; set; }
        public string ExperienceTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ExperienceStartMonthYear { get; set; }
        public DateTime? ExperienceEndMonthYear { get; set; }
        public string ExperienceLocation { get; set; }
        public string ExperienceDescription { get; set; }

        public string Skills { get; set; }

        public string EducationSchoolCollege { get; set; }
        public string EducationDegree { get; set; }
        public string EducationFieldofstudy { get; set; }
        public int? EducationStartYear { get; set; }
        public int? EducationEndYear { get; set; }
        public decimal? EducationGrade { get; set; }
        public bool Insert(UserDetails model)
        {
            string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True"; // Replace with your actual connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO UserDetails (Name, City, Position, Describe, Email, Contact, Git, LinkedIn, WebLink, Picture) " +
                                                "VALUES (@name, @city, @position, @describe, @email, @contact, @git, @linkedin, @weblink, @picture)", con);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@city", model.City);
                cmd.Parameters.AddWithValue("@position", model.Position);
                cmd.Parameters.AddWithValue("@describe", model.Describe);
                cmd.Parameters.AddWithValue("@email", model.Email);
                cmd.Parameters.AddWithValue("@contact", model.Contact);
                cmd.Parameters.AddWithValue("@git", "https://github.com/dhwajshah");
                cmd.Parameters.AddWithValue("@linkedin", model.LinkedIn);
                cmd.Parameters.AddWithValue("@weblink", model.WebLink);
                cmd.Parameters.AddWithValue("@picture", model.Picture);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                return false;
            }
        }

        public static List<UserDetails> Select()
        {
            List<UserDetails> userDetailsList = new List<UserDetails>();
            string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True";
            string query = @"
        SELECT 
            ud.UserID,
            ud.Name,
            ud.City,
            ud.Position,
            ud.Describe,
            ud.Email,
            ud.Contact,
            ud.Git,
            ud.LinkedIn,
            ud.WebLink,
            ud.Picture,
            a.AboutText,
            e.Title AS ExperienceTitle,
            e.CompanyName,
            e.StartMonthYear AS ExperienceStartMonthYear,
            e.EndMonthYear AS ExperienceEndMonthYear,
            e.Location AS ExperienceLocation,
            e.Description AS ExperienceDescription,
            s.Skill AS Skills,
            edu.SchoolCollege AS EducationSchoolCollege,
            edu.Degree AS EducationDegree,
            edu.Fieldofstudy AS EducationFieldofstudy,
            edu.StartYear AS EducationStartYear,
            edu.EndYear AS EducationEndYear,
            edu.Grade AS EducationGrade
        FROM 
            UserDetails ud
        LEFT JOIN 
            About a ON ud.UserID = a.UserID
        LEFT JOIN 
            Experience e ON ud.UserID = e.UserID
        LEFT JOIN 
            Skills s ON ud.UserID = s.UserID
        LEFT JOIN
            Education edu ON ud.UserID = edu.UserID;
    ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserDetails userDetails = new UserDetails();
                    userDetails.UserID = Convert.ToInt32(rdr["UserID"]);
                    userDetails.Name = rdr["Name"].ToString();
                    userDetails.City = rdr["City"].ToString();
                    userDetails.Position = rdr["Position"].ToString();
                    userDetails.Describe = rdr["Describe"].ToString();
                    userDetails.Email = rdr["Email"].ToString();
                    userDetails.Contact = rdr["Contact"].ToString();
                    userDetails.Git = rdr["Git"].ToString();
                    userDetails.LinkedIn = rdr["LinkedIn"].ToString();
                    userDetails.WebLink = rdr["WebLink"].ToString();
                    userDetails.Picture = rdr["Picture"].ToString();
                    userDetails.AboutText = rdr["AboutText"].ToString();
                    userDetails.ExperienceTitle = rdr["ExperienceTitle"].ToString();
                    userDetails.CompanyName = rdr["CompanyName"].ToString();
                    userDetails.ExperienceStartMonthYear = rdr["ExperienceStartMonthYear"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["ExperienceStartMonthYear"]);
                    userDetails.ExperienceEndMonthYear = rdr["ExperienceEndMonthYear"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["ExperienceEndMonthYear"]);
                    userDetails.ExperienceLocation = rdr["ExperienceLocation"].ToString();
                    userDetails.ExperienceDescription = rdr["ExperienceDescription"].ToString();
                    userDetails.Skills = rdr["Skills"].ToString();
                    userDetails.EducationSchoolCollege = rdr["EducationSchoolCollege"].ToString();
                    userDetails.EducationDegree = rdr["EducationDegree"].ToString();
                    userDetails.EducationFieldofstudy = rdr["EducationFieldofstudy"].ToString();
                    userDetails.EducationStartYear = rdr["EducationStartYear"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["EducationStartYear"]);
                    userDetails.EducationEndYear = rdr["EducationEndYear"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["EducationEndYear"]);
                    userDetails.EducationGrade = rdr["EducationGrade"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(rdr["EducationGrade"]);

                    userDetailsList.Add(userDetails);
                }
            }
            return userDetailsList;
        }

    }
}
