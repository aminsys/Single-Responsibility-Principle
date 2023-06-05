namespace Single_Responsibility_Principal 
{

    public class StudentRepository 
    {
        #region Fileds
        
        private readonly List<Student> _Students = new List<Student>();

        #endregion

        #region Methods

        public List<Student> GetAllStudents()
        {
            return _Students;
        }

        public void AddStudent(Student student)
        {
            _Students.Add(student);
        }

        // Should not be a part of the class StudentRepository
        public void ChangeStudentName(Student student, string name)
        {
            student.setName(name);
        }

        // Should not be a part of the class StudentRepository
        public Student CreateNewStudent(string name) => new Student(name);

        public Student GetStudentByName(string name) 
        {
            return _Students.FirstOrDefault(s => s.getName() == name);
        }

        public void RemoveStudent(Student student){
            _Students.Remove(student);
            Console.WriteLine("Student is deleted.");
        }

        #endregion
    }

    public class Student 
    {
        private string _name { get; set; }

        public Student(string name)
        {
            _name = name;
        }

        public string getName()
        {
            return _name;
        }

        public void setName(string name)
        {
            _name = name;
        }
    }

    public class Program 
    {
        public static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();
            
            // Demo of source code that doesn't follow SOLID principle
            studentRepository.AddStudent(new Student("Jin Muri"));
            studentRepository.AddStudent(studentRepository.CreateNewStudent("Sara Jess"));
            Console.WriteLine(studentRepository.GetStudentByName("Sara Jess").getName());
            Console.WriteLine(studentRepository.GetStudentByName("Jin Muri").getName());

            Student student = studentRepository.GetStudentByName("Jin Muri");
            Console.WriteLine("Remove the student Jin Muri from the list.");
            studentRepository.RemoveStudent(student);

            studentRepository.AddStudent(new Student("Kalle Anka"));
            Console.WriteLine(studentRepository.GetStudentByName("Kalle Anka").getName());

            student = studentRepository.GetStudentByName("Kalle Anka");
            string oldStudentName = student.getName();
            studentRepository.ChangeStudentName(student, "Mao Barang");
            Console.WriteLine("Student name is changed from  {0} to {1}", oldStudentName , student.getName());
            // End of demo
            
            Console.WriteLine("Show the students left in the list.");
            foreach(var s in studentRepository.GetAllStudents())
            {
                Console.WriteLine(s.getName());
            }
        }
    }
}