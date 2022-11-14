namespace Model
{
    public class Students
    {
        private int id;
        private string name;
        private int age;
        private string email;
        private long phone;

        public Students() { }

        public Students(int id,string name,int age,string email,long phone)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.phone = phone;
        }

        /// <summary>
        /// Student ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Student Name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Student Age
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Student EmailID
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Student PhoneNumber
        /// </summary>
        public long Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}