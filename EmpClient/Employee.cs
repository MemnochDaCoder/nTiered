namespace DAL
{
    /// <summary>
    /// Getters and setters.
    /// </summary>
    public class Employee
    {
        int employeeID;
        string lastName;    //  should be (20)  chars only
        string firstName;   //	should be (10)	chars only
        string title;       //	should be (30)	chars only
        string address;     //	should be (60)	chars only
        string city;        //	should be (50)	chars only
        string region;      //	should be (15)	chars only
        string postalCode;  //	should be (10)	chars only
        string country;     //	should be (15)	chars only
        string extension;   //	should be (4)	chars only
        string salary;      //  should be (10)  chars only
        string dept;        //  should be (10)  chars only
        string supervisor;  //  should be (20)  chars only
        string tenure;      //  should be (8)  chars only

        /// <summary>
        /// Getter and setter for emID.
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        /// <summary>
        /// Getter and setter for lastName.
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Getter and setter for firstName.
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        /// <summary>
        /// Getter and setter for title.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Getter and setter for address.
        /// </summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        /// <summary>
        /// Getter and setter for city.
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        /// <summary>
        /// Getter and setter for region.
        /// </summary>
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }

        /// <summary>
        /// Getter and setter for postalCode.
        /// </summary>
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }

        /// <summary>
        /// Getter and setter for country.
        /// </summary>
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        /// <summary>
        /// Getter and setter for extension.
        /// </summary>
        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
            }
        }

        public string Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        public string Department
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }

        public string Supervisor
        {
            get
            {
                return supervisor;
            }
            set
            {
                supervisor = value;
            }
        }

        public string Tenure
        {
            get
            {
                return tenure;
            }
            set
            {
                tenure = value;
            }
        }
    }
}
