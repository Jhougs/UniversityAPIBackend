using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAlCourses();
        IEnumerable<Course> GetCourseWithoutTemary();
        IEnumerable<Course> GetTemaryOfCourse();
        IEnumerable<Course> GetCourseOfStudent();


    }
}
